using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings.DummyApp;

/// <summary>
/// </summary>
public static class KeyValueList
{
    static KeyValueList()
    {
        AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("KeyValueList.json")
                     .Build();
    }

    /// <summary>
    /// </summary>
    public static IConfiguration AppSetting { get; }
}