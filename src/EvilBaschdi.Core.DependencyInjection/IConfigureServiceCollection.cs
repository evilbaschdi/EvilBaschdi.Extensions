using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public interface IConfigureServiceCollection : IRunFor<IServiceCollection>;