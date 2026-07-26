using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Generic configuration for file-based logging that can be reused across different applications and libraries.
/// </summary>
public class FileLoggerConfiguration : IFileLoggerConfiguration
{
    private string _logDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
    /// <summary>
    ///     Gets or sets the base directory where logs will be stored.
    ///     Defaults to {AppContext.BaseDirectory}/logs
    /// </summary>
    public string LogDirectory
    {
        get => _logDirectory;
        set => _logDirectory = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _logFileNamePattern = "app-{date}.log";
    /// <summary>
    ///     Gets or sets the log file name pattern.
    ///     Use {date} as a placeholder for the timestamp based on <see cref="LogInterval" />.
    ///     Example: "myapp-{date}.log"
    /// </summary>
    public string LogFileNamePattern
    {
        get => _logFileNamePattern;
        set => _logFileNamePattern = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    ///     Gets or sets the log interval.
    ///     Defaults to <see cref="LoggingFileInterval.PerDay" />.
    /// </summary>
    public LoggingFileInterval LogInterval { get; set; } = LoggingFileInterval.PerDay;

    /// <summary>
    ///     Gets or sets the number of days to retain log files.
    ///     Log files older than this will be automatically deleted.
    /// </summary>
    public int LogRetentionDays { get; set; } = 7;

    /// <summary>
    ///     Gets or sets the minimum log level.
    /// </summary>
    public LogLevel MinimumLogLevel { get; set; } = LogLevel.Debug;

    private string _headline;
    /// <summary>
    ///     Gets or sets the headline for the log file.
    ///     If provided, it will be written as the first line of a new log file.
    /// </summary>
    public string Headline
    {
        get => _headline;
        set => _headline = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to include the timestamp in the log entry.
    ///     Defaults to true.
    /// </summary>
    public bool IncludeTimestamp { get; set; } = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include the log level in the log entry.
    ///     Defaults to true.
    /// </summary>
    public bool IncludeLogLevel { get; set; } = true;

    /// <summary>
    ///     Gets the log directory path, ensuring it exists.
    ///     Cleans up old log files based on retention policy.
    /// </summary>
    public string GetLogDirectory()
    {
        if (!Directory.Exists(LogDirectory))
        {
            Directory.CreateDirectory(LogDirectory);
        }

        CleanOldLogs();
        return LogDirectory;
    }

    /// <summary>
    ///     Gets the full path to the current log file.
    /// </summary>
    public string GetLogFilePath()
    {
        var logDir = GetLogDirectory();
        var timestampFormat = LogInterval.ToTimestampFormat();
        var logFileName = LogFileNamePattern.Replace("{date}", DateTime.Now.ToString(timestampFormat));
        return Path.Combine(logDir, logFileName);
    }

    /// <summary>
    ///     Cleans up log files older than the retention period.
    /// </summary>
    private void CleanOldLogs()
    {
        try
        {
            var logDir = new DirectoryInfo(LogDirectory);
            var cutoffDate = DateTime.Now.AddDays(-LogRetentionDays);

            // Extract the pattern prefix (everything before {date})
            var patternPrefix = LogFileNamePattern.Split('{')[0];
            var searchPattern = $"{patternPrefix}*.log";

            foreach (var file in logDir.GetFiles(searchPattern))
            {
                if (file.LastWriteTime < cutoffDate)
                {
                    file.Delete();
                }
            }
        }
        catch
        {
            // Silently fail log cleanup to avoid breaking the app
        }
    }

    /// <summary>
    ///     Configures file-based logging using this configuration.
    /// </summary>
    public void Configure(ILoggingBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.ClearProviders();
        builder.SetMinimumLevel(MinimumLogLevel);
#pragma warning disable CA2000

        builder.AddProvider(new SimpleFileLoggerProvider(GetLogFilePath(), MinimumLogLevel, Headline, IncludeTimestamp, IncludeLogLevel));
#pragma warning restore CA2000
    }
}