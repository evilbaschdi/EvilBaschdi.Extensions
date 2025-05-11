namespace EvilBaschdi.Core.DependencyInjection;

/// <inheritdoc />
public interface IHandleAppStartup<TOut> : ITaskOfValueFor<IServiceProvider, TOut>;