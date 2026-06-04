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