namespace EvilBaschdi.DependencyInjection.Tests;

public class HandleAppStartupTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleAppStartup<string>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(HandleAppStartup<string> sut)
    {
        sut.Should().BeAssignableTo<IHandleAppStartup<string>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleAppStartup<string>).GetMethods().Where(method => !method.IsAbstract));
    }
}