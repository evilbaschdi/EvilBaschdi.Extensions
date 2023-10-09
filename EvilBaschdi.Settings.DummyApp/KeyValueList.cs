using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings.DummyApp;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
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
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public static IConfiguration AppSetting { get; }
}