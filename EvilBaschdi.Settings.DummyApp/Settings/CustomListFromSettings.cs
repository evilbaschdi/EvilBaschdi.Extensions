using EvilBaschdi.Settings.ByMachineAndUser;

namespace EvilBaschdi.Settings.DummyApp.Settings;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="appSettingByKey"></param>
/// <exception cref="ArgumentNullException"></exception>
public class CustomListFromSettings(
    IAppSettingByKey appSettingByKey) : ICustomListFromSettings
{
    private const string Key = "CustomList";
    private readonly IAppSettingByKey _appSettingByKey = appSettingByKey ?? throw new ArgumentNullException(nameof(appSettingByKey));

    /// <inheritdoc cref="string" />
    public List<string> Value
    {
        get => _appSettingByKey.ValueFor<List<string>>(Key);
        set => _appSettingByKey.RunFor(Key, value);
    }
}