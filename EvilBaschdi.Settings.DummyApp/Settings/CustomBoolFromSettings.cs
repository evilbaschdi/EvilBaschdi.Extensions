using EvilBaschdi.Settings.ByMachineAndUser;

namespace EvilBaschdi.Settings.DummyApp.Settings;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="appSettingByKey"></param>
/// <exception cref="ArgumentNullException"></exception>
public class CustomBoolFromSettings(IAppSettingByKey appSettingByKey) : ICustomBoolFromSettings
{
    private const string Key = "CustomBool";
    private readonly IAppSettingByKey _appSettingByKey = appSettingByKey ?? throw new ArgumentNullException(nameof(appSettingByKey));

    /// <inheritdoc cref="string" />
    public bool Value
    {
        get => _appSettingByKey.ValueFor<bool>(Key);
        set => _appSettingByKey.RunFor(Key, value);
    }
}