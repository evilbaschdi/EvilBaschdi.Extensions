using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public interface IConfigureDelegateForConfigureServices : IRunFor2<HostBuilderContext, IServiceCollection>;