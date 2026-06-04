using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Simple file logger that writes to disk with thread-safe access.
/// </summary>
public sealed class SimpleFileLogger(
    string logFilePath,
    LogLevel minimumLogLevel,
    object lockObject,
    string headline = null,
    bool includeTimestamp = true,
    bool includeLogLevel = true) : ILogger
{
    private readonly string _logFilePath = logFilePath ?? throw new ArgumentNullException(nameof(logFilePath));

    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly LogLevel _minimumLogLevel = minimumLogLevel;
    private readonly object _lockObject = lockObject ?? throw new ArgumentNullException(nameof(lockObject));

    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly string _headline = headline;

    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly bool _includeTimestamp = includeTimestamp;

    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly bool _includeLogLevel = includeLogLevel;

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state)
        where TState : notnull =>
        NullScope.Instance;

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel) => logLevel >= _minimumLogLevel;

    /// <inheritdoc />
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var message = formatter(state, exception);
        var logEntry = FormatLogEntry(logLevel, message, exception);

        lock (_lockObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_headline) && !File.Exists(_logFilePath))
                {
                    File.AppendAllText(_logFilePath, _headline + Environment.NewLine);
                }

                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch
            {
                // Silently fail to avoid breaking the app
            }
        }
    }

    private string FormatLogEntry(LogLevel logLevel, string message, Exception exception)
    {
        var entry = "";

        if (_includeTimestamp)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            entry += $"[{timestamp}] ";
        }

        if (_includeLogLevel)
        {
            var level = logLevel.ToString().ToUpperInvariant().PadRight(5);
            entry += $"{level} ";
        }

        entry += message;

        if (exception is not null)
        {
            entry += Environment.NewLine + exception;
        }

        return entry;
    }

    private sealed class NullScope : IDisposable
    {
        public static readonly NullScope Instance = new();

        public void Dispose()
        {
            // Nothing to dispose
        }
    }
}