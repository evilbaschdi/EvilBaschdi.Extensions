using EvilBaschdi.Core.Settings.Writable;

namespace EvilBaschdi.Core.Settings.ByMachineAndUser;

/// <inheritdoc cref="WritableSettingsFromJsonFile" />
public class AppSettingsFromJsonFile : WritableSettingsFromJsonFile, IAppSettingsFromJsonFile
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AppSettingsFromJsonFile()
        : base("Settings/App.json")
    {
    }
}