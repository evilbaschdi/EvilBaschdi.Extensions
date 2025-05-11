using EvilBaschdi.Core.Settings.Writable;

namespace EvilBaschdi.Core.Settings.ByMachineAndUser;

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