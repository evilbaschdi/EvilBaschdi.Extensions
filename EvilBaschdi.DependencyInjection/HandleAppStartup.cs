using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class HandleAppStartup : IHandleAppStartup
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
    public async Task<T> ValueForAsync<T>(IServiceProvider serviceProvider)
        //where T : Window
    {
        //#if (!DEBUG)
        //ThemeManager.Current.SyncTheme(ThemeSyncMode.SyncAll);
        //#endif

        await _hostInstance.Value.StartAsync();
        var window = serviceProvider.GetRequiredService<T>();

        return window;
    }
}