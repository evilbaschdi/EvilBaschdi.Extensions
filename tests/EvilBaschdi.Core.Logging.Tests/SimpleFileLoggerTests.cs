using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging.Tests;

public class SimpleFileLoggerTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SimpleFileLogger).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(SimpleFileLogger sut)
    {
        sut.Should().BeAssignableTo<ILogger>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SimpleFileLogger).GetMethods().Where(method => !method.IsAbstract && method.Name != "Log"));
    }

    [Fact]
    public void Log_WritesMessageToFile()
    {
        var tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".log");
        try
        {
            var lockObject = new object();
            var sut = new SimpleFileLogger(tempFile, LogLevel.Information, lockObject, "Headline");
            var eventId = new EventId(1);
            var state = "TestState";

            sut.Log(LogLevel.Information, eventId, state, null, (s, _) => s.ToString());

            var fileContent = File.ReadAllText(tempFile);
            fileContent.Should().Contain("Headline");
            fileContent.Should().Contain("TestState");
        }
        finally
        {
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
    }
}