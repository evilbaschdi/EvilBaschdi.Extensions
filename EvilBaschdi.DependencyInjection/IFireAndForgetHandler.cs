namespace EvilBaschdi.DependencyInjection;

/// <summary>
///     Fire and Forget
/// </summary>
public interface IFireAndForgetHandler<out T> : IRunFor<Func<T, Task>>;