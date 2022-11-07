using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public interface IInitServiceProviderByHostBuilder : IValueFor<Action<HostBuilderContext, IServiceCollection>, IServiceProvider>
{
}