using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class ConfigureServicesByHostBuilderAndConfigureDelegate : IConfigureServicesByHostBuilderAndConfigureDelegate
{
    private readonly Action<HostBuilderContext, IServiceCollection> _configureDelegate;
    private readonly IHostInstance _hostInstance;

    /// <summary>
    ///     Configure
    /// </summary>
    /// <param name="hostInstance"></param>
    /// <param name="configureDelegate"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ConfigureServicesByHostBuilderAndConfigureDelegate([NotNull] IHostInstance hostInstance, [NotNull] Action<HostBuilderContext, IServiceCollection> configureDelegate)
    {
        _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));
        _configureDelegate = configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate));
    }

    /// <inheritdoc />
    public IServiceProvider Value
    {
        get
        {
            _hostInstance.Value = Host.CreateDefaultBuilder()
                                      .ConfigureServices(_configureDelegate)
                                      .Build();

            return _hostInstance.Value.Services;
        }
    }
}