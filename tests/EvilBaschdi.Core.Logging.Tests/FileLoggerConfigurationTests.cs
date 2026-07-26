namespace EvilBaschdi.Core.Logging.Tests;

public class FileLoggerConfigurationTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(FileLoggerConfiguration).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(FileLoggerConfiguration sut)
    {
        sut.Should().BeAssignableTo<IFileLoggerConfiguration>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(FileLoggerConfiguration).GetMethods().Where(method => !method.IsAbstract));
    }
}