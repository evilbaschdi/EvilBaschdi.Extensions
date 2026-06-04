using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Simple file-based logging provider.
///     Can be used standalone or via FileLoggerConfiguration.
/// </summary>
public sealed class SimpleFileLoggerProvider(
    string logFilePath,
    LogLevel minimumLogLevel = LogLevel.Debug,
    string headline = "",
    bool includeTimestamp = true,
    bool includeLogLevel = true) : ILoggerProvider
{
    private readonly string _logFilePath = logFilePath ?? throw new ArgumentNullException(nameof(logFilePath));

    // ReSharper disable ReplaceWithPrimaryConstructorParameter
    private readonly LogLevel _minimumLogLevel = minimumLogLevel;
    private readonly string _headline = headline ?? throw new ArgumentNullException(nameof(headline));
    private readonly bool _includeTimestamp = includeTimestamp;
    private readonly bool _includeLogLevel = includeLogLevel;
    // ReSharper restore ReplaceWithPrimaryConstructorParameter

    private readonly object _lockObject = new();

    /// <inheritdoc />
    public ILogger CreateLogger(string categoryName)
    {
        ArgumentNullException.ThrowIfNull(categoryName);
        return new SimpleFileLogger(_logFilePath, _minimumLogLevel, _lockObject, _headline, _includeTimestamp, _includeLogLevel);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // Nothing to dispose
    }
}