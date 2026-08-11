namespace EvilBaschdi.Core.Logging.Tests;

public class LogFilePathWithIntervalTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LogFilePathWithInterval).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(LogFilePathWithInterval sut)
    {
        sut.Should().BeAssignableTo<ILogFilePathWithInterval>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LogFilePathWithInterval).GetMethods().Where(method => !method.IsAbstract));
    }
}