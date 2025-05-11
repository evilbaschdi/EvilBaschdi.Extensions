namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public interface IHandleAppStartup<TOut> : ITaskOfValueFor<IServiceProvider, TOut>;