namespace EvilBaschdi.Core.Logging;

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
    public static LoggingFileInterval ToLoggingFileInterval([NotNull] this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        return value.ToLower() switch
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