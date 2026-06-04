using Microsoft.Extensions.Logging;

namespace EvilBaschdi.Core.Logging.Tests;

public class SimpleFileLoggerProviderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SimpleFileLoggerProvider).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(SimpleFileLoggerProvider sut)
    {
        sut.Should().BeAssignableTo<ILoggerProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SimpleFileLoggerProvider).GetMethods().Where(method => !method.IsAbstract));
    }
}