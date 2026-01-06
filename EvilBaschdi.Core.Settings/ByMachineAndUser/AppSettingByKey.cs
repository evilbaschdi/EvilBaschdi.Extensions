using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;

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

        var jsonObject = JsonNode.Parse(settings)?.AsObject();

        if (jsonObject == null)
        {
            return;
        }

        jsonObject[key] = JsonSerializer.SerializeToNode(value);

        if (string.IsNullOrWhiteSpace(settingsFileName))
        {
            return;
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(settings, jsonObject.ToJsonString(options));
    }
}