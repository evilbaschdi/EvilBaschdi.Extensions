using EvilBaschdi.Settings.Writable;

namespace EvilBaschdi.Settings.ByMachineAndUser;

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