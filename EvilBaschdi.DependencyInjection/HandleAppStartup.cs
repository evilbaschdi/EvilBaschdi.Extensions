using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="hostInstance"></param>
/// <exception cref="ArgumentNullException"></exception>
public class HandleAppStartup<TOut>([NotNull] IHostInstance hostInstance) : IHandleAppStartup<TOut>
{
    private readonly IHostInstance _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));

    /// <inheritdoc />
    public async Task<TOut> ValueFor(IServiceProvider serviceProvider)
    {
        await _hostInstance.Value.StartAsync();
        var window = serviceProvider.GetRequiredService<TOut>();

        return window;
    }
}