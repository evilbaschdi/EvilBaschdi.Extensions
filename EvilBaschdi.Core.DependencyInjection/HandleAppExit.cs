namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="hostInstance"></param>
/// <exception cref="ArgumentNullException"></exception>
public class HandleAppExit(
    [NotNull] IHostInstance hostInstance) : IHandleAppExit
{
    private readonly IHostInstance _hostInstance = hostInstance ?? throw new ArgumentNullException(nameof(hostInstance));

    /// <inheritdoc />
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await _hostInstance.Value.StopAsync(cancellationToken);

        _hostInstance.Value.Dispose();
    }
}