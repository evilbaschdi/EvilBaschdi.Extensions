using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class ConfigureServicesByHostBuilderAndConfigureDelegate : IConfigureServicesByHostBuilderAndConfigureDelegate
{
    private readonly IConfigureDelegateForConfigureServices _configureDelegateForConfigureServices;
    private readonly IHostInstance _hostInstance;

    /// <summary>
    ///     Configure
    /// </summary>
    /// <param name="hostInstance"></param>
    /// <param name="configureDelegateForConfigureServices"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ConfigureServicesByHostBuilderAndConfigureDelegate([NotNull] IHostInstance hostInstance,
                                                              [NotNull] IConfigureDelegateForConfigureServices configureDelegateForConfigureServices)
    {
        _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));
        _configureDelegateForConfigureServices = configureDelegateForConfigureServices ?? throw new ArgumentNullException(nameof(configureDelegateForConfigureServices));
    }

    /// <inheritdoc />
    public IServiceProvider Value
    {
        get
        {
            _hostInstance.Value = Host.CreateDefaultBuilder()
                                      .ConfigureServices(_configureDelegateForConfigureServices.RunFor)
                                      .Build();

            return _hostInstance.Value.Services;
        }
    }
}