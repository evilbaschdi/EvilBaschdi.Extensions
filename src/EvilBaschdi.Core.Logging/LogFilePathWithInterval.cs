namespace EvilBaschdi.Core.Logging;

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