namespace EvilBaschdi.Core.Logging;

/// <summary>
///     Intervals for logging files.
/// </summary>
public enum LoggingFileInterval
{
    /// <summary>
    ///     None.
    /// </summary>
    None,

    /// <summary>
    ///     Per minute.
    /// </summary>
    PerMinute,

    /// <summary>
    ///     Per hour.
    /// </summary>
    PerHour,

    /// <summary>
    ///     Per day.
    /// </summary>
    PerDay,

    /// <summary>
    ///     Per month.
    /// </summary>
    PerMonth,

    /// <summary>
    ///     Per year.
    /// </summary>
    PerYear
}

/// <summary>
///     Extensions for <see cref="LoggingFileInterval" />.
/// </summary>
public static class LoggingFileIntervalExtensions
{
    /// <summary>
    ///     Converts a string to <see cref="LoggingFileInterval" />.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static LoggingFileInterval ToLoggingFileInterval(this string value)
    {
        return value?.ToLower() switch
        {
            "per minute" => LoggingFileInterval.PerMinute,
            "per hour" => LoggingFileInterval.PerHour,
            "per day" => LoggingFileInterval.PerDay,
            "per month" => LoggingFileInterval.PerMonth,
            "per year" => LoggingFileInterval.PerYear,
            _ => LoggingFileInterval.None
        };
    }

    /// <summary>
    ///     Gets the timestamp format for the given interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static string ToTimestampFormat(this LoggingFileInterval interval)
    {
        return interval switch
        {
            LoggingFileInterval.PerMinute => "yyyy-MM-dd_HHmm",
            LoggingFileInterval.PerHour => "yyyy-MM-dd_HH",
            LoggingFileInterval.PerDay => "yyyy-MM-dd",
            LoggingFileInterval.PerMonth => "yyyy-MM",
            LoggingFileInterval.PerYear => "yyyy",
            _ => "yyyy-MM-dd"
        };
    }
}

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

/// <inheritdoc />
public class LogFilePathWithInterval : ILogFilePathWithInterval
{
    /// <inheritdoc />
    public string ValueFor(string loggingPath, string appName, LoggingFileInterval interval, DateTime currentLoggingDateTime, string extension = "csv")
    {
        ArgumentNullException.ThrowIfNull(loggingPath);
        ArgumentNullException.ThrowIfNull(appName);
        ArgumentNullException.ThrowIfNull(extension);

        var timestampFormat = interval.ToTimestampFormat();
        return Path.Combine(loggingPath, $"{appName}_{currentLoggingDateTime.ToString(timestampFormat)}.{extension}");
    }

    /// <inheritdoc />
    public bool IsCurrentDateTimeValid(LoggingFileInterval interval, DateTime currentLoggingDateTime)
    {
        var dateTimeNow = DateTime.Now;
        return interval switch
        {
            LoggingFileInterval.PerMinute => currentLoggingDateTime.Minute == dateTimeNow.Minute,
            LoggingFileInterval.PerHour => currentLoggingDateTime.Hour == dateTimeNow.Hour,
            LoggingFileInterval.PerDay => currentLoggingDateTime.Day == dateTimeNow.Day,
            LoggingFileInterval.PerMonth => currentLoggingDateTime.Month == dateTimeNow.Month,
            LoggingFileInterval.PerYear => currentLoggingDateTime.Year == dateTimeNow.Year,
            _ => true
        };
    }
}