using EvilBaschdi.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public interface IConfigureServices : IRunFor2<HostBuilderContext, IServiceCollection>
{
}