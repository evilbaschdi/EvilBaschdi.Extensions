using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace EvilBaschdi.Core.Settings.ByMachineAndUser;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="appSettingsFromJsonFile"></param>
/// <param name="appSettingsFromJsonFileByMachineAndUser"></param>
/// <exception cref="ArgumentNullException"></exception>
public class AppSettingByKey(
    [NotNull] IAppSettingsFromJsonFile appSettingsFromJsonFile,
    [NotNull] IAppSettingsFromJsonFileByMachineAndUser appSettingsFromJsonFileByMachineAndUser) : IAppSettingByKey
{
    private readonly IAppSettingsFromJsonFile _appSettingsFromJsonFile = appSettingsFromJsonFile ?? throw new ArgumentNullException(nameof(appSettingsFromJsonFile));

    private readonly IAppSettingsFromJsonFileByMachineAndUser _appSettingsFromJsonFileByMachineAndUser =
        appSettingsFromJsonFileByMachineAndUser ?? throw new ArgumentNullException(nameof(appSettingsFromJsonFileByMachineAndUser));

    /// <inheritdoc />
    public string ValueFor([NotNull] string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var fallbackConfiguration = _appSettingsFromJsonFile.Value;
        var currentConfiguration = _appSettingsFromJsonFileByMachineAndUser.Value;

        var fallbackValue = fallbackConfiguration?[key];
        var currentValue = currentConfiguration?[key];

        return !string.IsNullOrWhiteSpace(currentValue)
            ? currentValue
            : fallbackValue;
    }

    /// <exception cref="ArgumentNullException"></exception>
    /// <inheritdoc />
    public void RunFor([NotNull] string key, [NotNull] string value)
    {
        ArgumentNullException.ThrowIfNull(key);

        var configuration = _appSettingsFromJsonFileByMachineAndUser.Value;
        configuration[key] = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <inheritdoc />
    public TOut ValueFor<TOut>([NotNull] string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var fallbackConfiguration = _appSettingsFromJsonFile.Value;
        var currentConfiguration = _appSettingsFromJsonFileByMachineAndUser.Value;

        if (fallbackConfiguration == null)
        {
            return default;
        }

        var fallbackValue = fallbackConfiguration.GetSection(key).Get<TOut>();

        return currentConfiguration == null || currentConfiguration.GetSection(key).Get<TOut>() == null ? fallbackValue : currentConfiguration.GetSection(key).Get<TOut>();
    }

    /// <inheritdoc />
    public void RunFor<TIn>(string key, TIn value)
    {
        ArgumentNullException.ThrowIfNull(key);

        var settingsFileName = _appSettingsFromJsonFileByMachineAndUser.SettingsFileName;
        var settings = File.ReadAllText(!File.Exists(settingsFileName) ? _appSettingsFromJsonFile.SettingsFileName : settingsFileName);

        var jObject = JObject.Parse(settings);
        jObject[key] = JToken.FromObject(value);

        if (settingsFileName != null)
        {
            File.WriteAllText(settingsFileName, jObject.ToString());
        }
    }
}