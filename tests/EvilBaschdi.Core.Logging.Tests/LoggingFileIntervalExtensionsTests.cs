namespace EvilBaschdi.Core.Logging.Tests;

public class LoggingFileIntervalExtensionsTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LoggingFileIntervalExtensions).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LoggingFileIntervalExtensions).GetMethods().Where(method => !method.IsAbstract));
    }

    [Theory]
    [InlineData("per minute", LoggingFileInterval.PerMinute)]
    [InlineData("per hour", LoggingFileInterval.PerHour)]
    [InlineData("per day", LoggingFileInterval.PerDay)]
    [InlineData("per month", LoggingFileInterval.PerMonth)]
    [InlineData("per year", LoggingFileInterval.PerYear)]
    [InlineData("unknown", LoggingFileInterval.None)]
    public void ToLoggingFileInterval_ReturnsExpectedInterval(string input, LoggingFileInterval expected)
    {
        input.ToLoggingFileInterval().Should().Be(expected);
    }

    [Theory]
    [InlineData(LoggingFileInterval.PerMinute, "yyyy-MM-dd_HHmm")]
    [InlineData(LoggingFileInterval.PerHour, "yyyy-MM-dd_HH")]
    [InlineData(LoggingFileInterval.PerDay, "yyyy-MM-dd")]
    [InlineData(LoggingFileInterval.PerMonth, "yyyy-MM")]
    [InlineData(LoggingFileInterval.PerYear, "yyyy")]
    [InlineData(LoggingFileInterval.None, "yyyy-MM-dd")]
    public void ToTimestampFormat_ReturnsExpectedFormat(LoggingFileInterval interval, string expected)
    {
        interval.ToTimestampFormat().Should().Be(expected);
    }
}