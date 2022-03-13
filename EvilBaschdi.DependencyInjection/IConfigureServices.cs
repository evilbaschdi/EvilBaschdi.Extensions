using EvilBaschdi.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public interface IConfigureServices : IRunFor<IServiceCollection>
{
}