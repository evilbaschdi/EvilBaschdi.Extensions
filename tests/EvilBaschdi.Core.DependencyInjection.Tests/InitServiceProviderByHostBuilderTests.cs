using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.Core.DependencyInjection.Tests;

public class InitServiceProviderByHostBuilderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(InitServiceProviderByHostBuilder).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(InitServiceProviderByHostBuilder sut)
    {
        sut.Should().BeAssignableTo<IValueFor<Action<HostBuilderContext, IServiceCollection>, IServiceProvider>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(InitServiceProviderByHostBuilder).GetMethods().Where(method => !method.IsAbstract));
    }
}