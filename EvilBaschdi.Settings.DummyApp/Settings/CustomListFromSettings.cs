using EvilBaschdi.Settings.ByMachineAndUser;

namespace EvilBaschdi.Settings.DummyApp.Settings;

/// <inheritdoc />
public class CustomListFromSettings : ICustomListFromSettings
{
    private const string Key = "CustomList";
    private readonly IAppSettingByKey _appSettingByKey;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="appSettingByKey"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CustomListFromSettings(IAppSettingByKey appSettingByKey)
    {
        _appSettingByKey = appSettingByKey ?? throw new ArgumentNullException(nameof(appSettingByKey));
    }

    /// <inheritdoc cref="string" />
    public List<string> Value
    {
        get => _appSettingByKey.ValueFor<List<string>>(Key);
        set => _appSettingByKey.RunFor(Key, value);
    }
}