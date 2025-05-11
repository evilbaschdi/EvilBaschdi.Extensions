using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Core.Settings;

/// <inheritdoc />
public interface ISettingsFromJsonFile : IValue<IConfiguration>
{
    /// <summary>
    /// </summary>
    public string SettingsFileName { get; }
}