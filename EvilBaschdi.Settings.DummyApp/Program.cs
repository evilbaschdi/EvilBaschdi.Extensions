using EvilBaschdi.Settings.ByMachineAndUser;
using EvilBaschdi.Settings.DummyApp.Settings;

namespace EvilBaschdi.Settings.DummyApp;

// ReSharper disable once ArrangeTypeModifiers
// ReSharper disable once ClassNeverInstantiated.Global
class Program
{
    // ReSharper disable once ArrangeTypeMemberModifiers
    // ReSharper disable once UnusedParameter.Local
    static void Main()
    {
        IAppSettingsFromJsonFile appSettingsFromJsonFile = new AppSettingsFromJsonFile();
        IAppSettingsFromJsonFileByMachineAndUser appSettingsFromJsonFileByMachineAndUser = new AppSettingsFromJsonFileByMachineAndUser();
        IAppSettingByKey appSettingByKey = new AppSettingByKey(appSettingsFromJsonFile, appSettingsFromJsonFileByMachineAndUser);

        //var keyValueConfiguration = KeyValue.AppSetting;
        //Console.WriteLine(keyValueConfiguration["Black"]);
        //Console.WriteLine();
        //Console.WriteLine(keyValueConfiguration["Dei"]);

        //Console.WriteLine("---");
        //Console.WriteLine();

        //KeyValue.AppSetting["Black"] = "Coffee";
        //Console.WriteLine(keyValueConfiguration["Black"]);
        //Console.WriteLine();

        //var keyValueListAlterBridge = KeyValueList.AppSetting.GetSection("AlterBridge").Get<List<string>>() ?? new List<string>();
        //var keyValueListCreed = KeyValueList.AppSetting.GetSection("Creed").Get<List<string>>() ?? new List<string>();

        //keyValueListAlterBridge.ForEach(Console.WriteLine);
        //Console.WriteLine();
        //keyValueListCreed.ForEach(Console.WriteLine);

        ICustomListFromSettings customListFromSettings = new CustomListFromSettings(appSettingByKey);
        ICustomBoolFromSettings customBoolFromSettings = new CustomBoolFromSettings(appSettingByKey);

        foreach (var item in customListFromSettings.Value)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(customBoolFromSettings.Value);

        Console.WriteLine("---");

        var temp = customListFromSettings.Value;

        temp.Add("Something2");
        customListFromSettings.Value = temp;
        customBoolFromSettings.Value = true;

        foreach (var item in customListFromSettings.Value)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(customBoolFromSettings.Value);

        Console.WriteLine("---");
        Console.ReadLine();
    }
}