using EvilBaschdi.Core;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public interface IHandleAppStartup<TOut> : ITaskWithResultValueFor<IServiceProvider, TOut>
{
}