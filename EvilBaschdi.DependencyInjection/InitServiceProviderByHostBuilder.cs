using EvilBaschdi.Core;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class InitServiceProviderByHostBuilder : IValueFor<Action<HostBuilderContext, IServiceCollection>, IServiceProvider>
{
    private readonly IHostInstance _hostInstance;

    /// <summary>
    /// </summary>
    /// <param name="hostInstance"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public InitServiceProviderByHostBuilder([NotNull] IHostInstance hostInstance)
    {
        _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));
    }

    /// <inheritdoc />
    public IServiceProvider ValueFor(Action<HostBuilderContext, IServiceCollection> action)
    {
        _hostInstance.Value = Host.CreateDefaultBuilder()
                                  .ConfigureServices(action)
                                  .Build();

        return _hostInstance.Value.Services;
    }
}