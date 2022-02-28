using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class HandleAppStartup<TOut> : IHandleAppStartup<TOut>
{
    private readonly IHostInstance _hostInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="hostInstance"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public HandleAppStartup([NotNull] IHostInstance hostInstance)
    {
        _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));
    }

    /// <inheritdoc />
    public async Task<TOut> ValueForAsync(IServiceProvider serviceProvider)

    {
        await _hostInstance.Value.StartAsync();
        var window = serviceProvider.GetRequiredService<TOut>();

        return window;
    }
}