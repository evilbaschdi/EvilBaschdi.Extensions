using EvilBaschdi.Settings.Writable;

namespace EvilBaschdi.Settings.ByMachineAndUser;

/// <inheritdoc cref="WritableSettingsFromJsonFile" />
public class AppSettingsFromJsonFileByMachineAndUser : WritableSettingsFromJsonFile, IAppSettingsFromJsonFileByMachineAndUser
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AppSettingsFromJsonFileByMachineAndUser()
        : base($"Settings/App.{Environment.MachineName}.{Environment.UserName}.json", true)
    {
    }
}