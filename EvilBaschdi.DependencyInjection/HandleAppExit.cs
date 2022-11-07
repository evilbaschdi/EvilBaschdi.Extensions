using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class HandleAppExit : IHandleAppExit
{
    private readonly IHostInstance _hostInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="hostInstance"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public HandleAppExit([NotNull] IHostInstance hostInstance)
    {
        _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));
    }

    /// <inheritdoc />
    public async Task Value()
    {
        await _hostInstance.Value.StopAsync(TimeSpan.FromSeconds(5));

        _hostInstance.Value.Dispose();
    }
}