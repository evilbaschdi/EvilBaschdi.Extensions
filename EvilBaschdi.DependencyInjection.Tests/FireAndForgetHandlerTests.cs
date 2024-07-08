namespace EvilBaschdi.DependencyInjection.Tests;

public class FireAndForgetHandlerTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(FireAndForgetHandler<IConfigureServiceCollection>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(FireAndForgetHandler<IConfigureServiceCollection> sut)
    {
        sut.Should().BeAssignableTo<IFireAndForgetHandler<IConfigureServiceCollection>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(FireAndForgetHandler<IConfigureServiceCollection>).GetMethods().Where(method => !method.IsAbstract));
    }
}