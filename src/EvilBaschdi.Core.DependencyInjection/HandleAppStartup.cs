using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="hostInstance"></param>
/// <exception cref="ArgumentNullException"></exception>
public class HandleAppStartup<TOut>(
    [NotNull] IHostInstance hostInstance) : IHandleAppStartup<TOut>
{
    private readonly IHostInstance _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));

    /// <inheritdoc />
    public async Task<TOut> ValueForAsync([NotNull] IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        await _hostInstance.Value.StartAsync(cancellationToken);
        var window = serviceProvider.GetRequiredService<TOut>();

        return window;
    }
}