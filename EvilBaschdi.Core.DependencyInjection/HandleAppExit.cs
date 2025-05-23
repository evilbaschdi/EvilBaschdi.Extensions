﻿using Microsoft.Extensions.Hosting;

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
    public async Task RunAsync()
    {
        await _hostInstance.Value.StopAsync(TimeSpan.FromSeconds(5));

        _hostInstance.Value.Dispose();
    }
}