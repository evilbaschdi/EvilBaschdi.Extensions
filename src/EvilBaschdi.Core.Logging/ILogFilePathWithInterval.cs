namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Interface for log file path with interval.
/// </summary>
public interface ILogFilePathWithInterval
{
    /// <summary>
    ///     Gets the log file path.
    /// </summary>
    /// <param name="loggingPath"></param>
    /// <param name="appName"></param>
    /// <param name="interval"></param>
    /// <param name="currentLoggingDateTime"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    string ValueFor(string loggingPath, string appName, LoggingFileInterval interval, DateTime currentLoggingDateTime, string extension = "csv");

    /// <summary>
    ///     Checks if the current date time is valid for the given interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="currentLoggingDateTime"></param>
    /// <returns></returns>
    bool IsCurrentDateTimeValid(LoggingFileInterval interval, DateTime currentLoggingDateTime);
}