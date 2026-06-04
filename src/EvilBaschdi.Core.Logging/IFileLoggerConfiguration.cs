using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Generic configuration for file-based logging that can be reused across different applications and libraries.
/// </summary>
public interface IFileLoggerConfiguration
{
    /// <summary>
    ///     Gets or sets the base directory where logs will be stored.
    ///     Defaults to {AppContext.BaseDirectory}/logs
    /// </summary>
    string LogDirectory { get; set; }

    /// <summary>
    ///     Gets or sets the log file name pattern.
    ///     Use {date} as a placeholder for the timestamp based on <see cref="LogInterval" />.
    ///     Example: "myapp-{date}.log"
    /// </summary>
    string LogFileNamePattern { get; set; }

    /// <summary>
    ///     Gets or sets the log interval.
    ///     Defaults to <see cref="LoggingFileInterval.PerDay" />.
    /// </summary>
    LoggingFileInterval LogInterval { get; set; }

    /// <summary>
    ///     Gets or sets the number of days to retain log files.
    ///     Log files older than this will be automatically deleted.
    /// </summary>
    int LogRetentionDays { get; set; }

    /// <summary>
    ///     Gets or sets the minimum log level.
    /// </summary>
    LogLevel MinimumLogLevel { get; set; }

    /// <summary>
    ///     Gets or sets the headline for the log file.
    ///     If provided, it will be written as the first line of a new log file.
    /// </summary>
    string Headline { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to include the timestamp in the log entry.
    ///     Defaults to true.
    /// </summary>
    bool IncludeTimestamp { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to include the log level in the log entry.
    ///     Defaults to true.
    /// </summary>
    bool IncludeLogLevel { get; set; }

    /// <summary>
    ///     Gets the log directory path, ensuring it exists.
    ///     Cleans up old log files based on retention policy.
    /// </summary>
    string GetLogDirectory();

    /// <summary>
    ///     Gets the full path to the current log file.
    /// </summary>
    string GetLogFilePath();

    /// <summary>
    ///     Configures file-based logging using this configuration.
    /// </summary>
    void Configure(ILoggingBuilder builder);
}