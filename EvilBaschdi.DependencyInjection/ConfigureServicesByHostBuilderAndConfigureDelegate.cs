using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Configure
/// </summary>
/// <param name="hostInstance"></param>
/// <param name="configureDelegateForConfigureServices"></param>
/// <exception cref="ArgumentNullException"></exception>
public class ConfigureServicesByHostBuilderAndConfigureDelegate(
    [NotNull] IHostInstance hostInstance,
    [NotNull] IConfigureDelegateForConfigureServices configureDelegateForConfigureServices) : IConfigureServicesByHostBuilderAndConfigureDelegate
{
    private readonly IConfigureDelegateForConfigureServices _configureDelegateForConfigureServices =
        configureDelegateForConfigureServices ?? throw new ArgumentNullException(nameof(configureDelegateForConfigureServices));

    private readonly IHostInstance _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));

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