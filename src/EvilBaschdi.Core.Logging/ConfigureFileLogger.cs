using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Configuration for file-based logging.
///     Uses the generic <see cref="FileLoggerConfiguration" /> internally.
/// </summary>
public static class ConfigureFileLogger
{
    /// <summary>
    ///     Configures file-based logging for the watcher using sensible defaults.
    /// </summary>
    public static void AddFileLoggerConfiguration(this ILoggingBuilder builder, FileLoggerConfiguration config)
    {
        config.Configure(builder);
    }
}