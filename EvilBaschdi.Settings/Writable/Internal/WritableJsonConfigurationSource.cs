using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EvilBaschdi.Settings.Writable.Internal;

/// <inheritdoc />
public class WritableJsonConfigurationSource : JsonConfigurationSource
{
    /// <inheritdoc />
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        EnsureDefaults(builder);
        return new WritableJsonConfigurationProvider(this);
    }
}