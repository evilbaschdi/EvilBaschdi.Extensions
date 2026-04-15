using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
public interface IInitServiceProviderByHostBuilder : IValueFor<Action<HostBuilderContext, IServiceCollection>, IServiceProvider>;