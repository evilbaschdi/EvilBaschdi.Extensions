using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
/// <summary>
/// </summary>
/// <param name="hostInstance"></param>
/// <exception cref="ArgumentNullException"></exception>
public class InitServiceProviderByHostBuilder(
    [NotNull] IHostInstance hostInstance) : IInitServiceProviderByHostBuilder
{
    private readonly IHostInstance _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));

    /// <inheritdoc />
    public IServiceProvider ValueFor([NotNull] Action<HostBuilderContext, IServiceCollection> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        _hostInstance.Value = Host.CreateDefaultBuilder()
                                  .ConfigureServices(action)
                                  .Build();

        return _hostInstance.Value.Services;
    }
}