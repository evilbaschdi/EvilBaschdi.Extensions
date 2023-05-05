using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings.DummyApp;

/// <summary>
/// </summary>
public static class KeyValue
{
    static KeyValue()
    {
        AppSetting = new ConfigurationBuilder().Add(
            (Action<WritableJsonConfigurationSource>)(s =>
                                                      {
                                                          s.FileProvider = null;
                                                          s.Path = "KeyValue.json";
                                                          s.Optional = false;
                                                          s.ReloadOnChange = true;
                                                          s.ResolveFileProvider();
                                                      })).Build();
    }

    /// <summary>
    /// </summary>
    public static IConfiguration AppSetting { get; }
}