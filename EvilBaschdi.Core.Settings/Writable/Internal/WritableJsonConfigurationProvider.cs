using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace EvilBaschdi.Core.Settings.Writable.Internal;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="source"></param>
public class WritableJsonConfigurationProvider(
    JsonConfigurationSource source) : JsonConfigurationProvider(source)
{
    /// <inheritdoc />
    public override void Set(string key, string value)
    {
        ArgumentNullException.ThrowIfNull(key);

        ArgumentNullException.ThrowIfNull(value);

        base.Set(key, value);

        //Get Whole json file and change only passed key with passed value. It requires modification if you need to support change multi level json structure
        if (Source.FileProvider == null || Source.Path == null || Source.FileProvider == null)
        {
            return;
        }

        var fileFullPath = Source.FileProvider.GetFileInfo(Source.Path).PhysicalPath;
        if (fileFullPath == null)
        {
            return;
        }

        string output;
        if (File.Exists(fileFullPath))
        {
            var json = File.ReadAllText(fileFullPath);

            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            if (jsonObj == null)
            {
                return;
            }

            jsonObj[key] = value;
            output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        }
        else
        {
            var dict = new Dictionary<string, string>
                       {
                           { key, value }
                       };

            output = JsonConvert.SerializeObject(dict);
        }

        File.WriteAllText(fileFullPath, output);
    }
}