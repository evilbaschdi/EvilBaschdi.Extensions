using EvilBaschdi.Core.Settings.Writable.Internal;
using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Core.Settings.DummyApp;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
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
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public static IConfiguration AppSetting { get; }
}