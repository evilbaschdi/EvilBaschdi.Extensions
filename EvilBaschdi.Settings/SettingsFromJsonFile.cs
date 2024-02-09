using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings;

/// <inheritdoc cref="ISettingsFromJsonFile" />
// ReSharper disable once UnusedType.Global
public abstract class SettingsFromJsonFile : CachedValue<IConfiguration>, ISettingsFromJsonFile
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="settingsFileName"></param>
    protected SettingsFromJsonFile([NotNull] string settingsFileName)
    {
        ArgumentNullException.ThrowIfNull(settingsFileName);

        SettingsFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsFileName);
        AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile(settingsFileName)
                     .Build();
    }

    private IConfiguration AppSetting { get; }

    /// <inheritdoc />
    protected override IConfiguration NonCachedValue => AppSetting;

    /// <inheritdoc />
    public string SettingsFileName { get; }
}