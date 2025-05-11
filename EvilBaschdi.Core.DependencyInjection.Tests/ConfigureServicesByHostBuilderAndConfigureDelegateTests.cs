namespace EvilBaschdi.Core.DependencyInjection.Tests;

public class ConfigureServicesByHostBuilderAndConfigureDelegateTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ConfigureServicesByHostBuilderAndConfigureDelegate).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ConfigureServicesByHostBuilderAndConfigureDelegate sut)
    {
        sut.Should().BeAssignableTo<IConfigureServicesByHostBuilderAndConfigureDelegate>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ConfigureServicesByHostBuilderAndConfigureDelegate).GetMethods().Where(method => !method.IsAbstract));
    }
}