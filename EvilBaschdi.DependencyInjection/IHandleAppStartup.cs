namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public interface IHandleAppStartup<TOut> : ITaskOfWithInjection<IServiceProvider, TOut>;