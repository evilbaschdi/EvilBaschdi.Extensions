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
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("per minute", LoggingFileInterval.PerMinute)]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("per hour", LoggingFileInterval.PerHour)]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("per day", LoggingFileInterval.PerDay)]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("per month", LoggingFileInterval.PerMonth)]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("per year", LoggingFileInterval.PerYear)]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("unknown", LoggingFileInterval.None)]
    public void ToLoggingFileInterval_ReturnsExpectedInterval(string input, LoggingFileInterval expected)
    {
        input.ToLoggingFileInterval().Should().Be(expected);
    }

    [Theory]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.PerMinute, "yyyy-MM-dd_HHmm")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.PerHour, "yyyy-MM-dd_HH")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.PerDay, "yyyy-MM-dd")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.PerMonth, "yyyy-MM")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.PerYear, "yyyy")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData(LoggingFileInterval.None, "yyyy-MM-dd")]
    public void ToTimestampFormat_ReturnsExpectedFormat(LoggingFileInterval interval, string expected)
    {
        interval.ToTimestampFormat().Should().Be(expected);
    }
}