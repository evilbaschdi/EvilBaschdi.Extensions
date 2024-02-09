using EvilBaschdi.Settings.Writable.Internal;
using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings.Writable;

/// <inheritdoc cref="ISettingsFromJsonFile" />
// ReSharper disable once UnusedType.Global
public abstract class WritableSettingsFromJsonFile : ISettingsFromJsonFile
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="settingsFileName"></param>
    /// <param name="optional"></param>
    protected WritableSettingsFromJsonFile([NotNull] string settingsFileName, bool optional = false)
    {
        ArgumentNullException.ThrowIfNull(settingsFileName);

        SettingsFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsFileName);
        AppSetting = new ConfigurationBuilder().Add(
            (Action<WritableJsonConfigurationSource>)(s =>
                                                      {
                                                          s.FileProvider = null;
                                                          s.Path = settingsFileName;
                                                          s.Optional = optional;
                                                          s.ReloadOnChange = true;
                                                          s.ResolveFileProvider();
                                                      })).Build();
    }

    private IConfiguration AppSetting { get; }

    /// <inheritdoc />
    public IConfiguration Value => AppSetting;

    /// <inheritdoc />
    public string SettingsFileName { get; }
}