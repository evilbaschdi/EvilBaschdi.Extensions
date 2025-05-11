namespace EvilBaschdi.Core.DependencyInjection.Tests;

public class ChainConfiguratorImplementationTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ChainConfiguratorImplementation<string>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ChainConfiguratorImplementation<string> sut)
    {
        sut.Should().BeAssignableTo<IChainConfigurator<string>>();
    }

    //[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    //public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    //{
    //    assertion.Verify(typeof(ChainConfiguratorImplementation<string>).GetMethods().Where(method => !method.IsAbstract));
    //}
}