namespace EvilBaschdi.DependencyInjection.Tests;

public class HostInstanceTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HostInstance).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(HostInstance sut)
    {
        sut.Should().BeAssignableTo<IHostInstance>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HostInstance).GetMethods().Where(method => !method.IsAbstract));
    }
}