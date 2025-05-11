namespace EvilBaschdi.Core.DependencyInjection.Tests;

public class HandleAppExitTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleAppExit).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(HandleAppExit sut)
    {
        sut.Should().BeAssignableTo<IHandleAppExit>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleAppExit).GetMethods().Where(method => !method.IsAbstract));
    }
}