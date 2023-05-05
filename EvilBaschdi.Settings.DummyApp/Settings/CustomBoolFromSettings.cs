using EvilBaschdi.Settings.ByMachineAndUser;

namespace EvilBaschdi.Settings.DummyApp.Settings;

/// <inheritdoc />
public class CustomBoolFromSettings : ICustomBoolFromSettings
{
    private const string Key = "CustomBool";
    private readonly IAppSettingByKey _appSettingByKey;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="appSettingByKey"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CustomBoolFromSettings(IAppSettingByKey appSettingByKey)
    {
        _appSettingByKey = appSettingByKey ?? throw new ArgumentNullException(nameof(appSettingByKey));
    }

    /// <inheritdoc cref="string" />
    public bool Value
    {
        get => _appSettingByKey.ValueFor<bool>(Key);
        set => _appSettingByKey.RunFor(Key, value);
    }
}