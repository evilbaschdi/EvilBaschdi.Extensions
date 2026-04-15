using EvilBaschdi.Core.Settings.ByMachineAndUser;
using EvilBaschdi.Core.Settings.Writable;

namespace EvilBaschdi.Core.Settings.DummyApp;

/// <inheritdoc cref="WritableSettingsFromJsonFile" />
public class DummyAppSettingsFromJsonFileByMachineAndUser : WritableSettingsFromJsonFile, IAppSettingsFromJsonFileByMachineAndUser
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public DummyAppSettingsFromJsonFileByMachineAndUser()
        : base($"Settings/App.{Environment.MachineName}.{Environment.UserName}.Dummy.json", true)
    {
    }
}