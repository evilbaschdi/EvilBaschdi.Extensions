using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class FireAndForgetHandler<T> : IFireAndForgetHandler<T>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="serviceScopeFactory"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public FireAndForgetHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    /// <inheritdoc />
    public void RunFor(Func<T, Task> func)
    {
        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        async Task Function()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<T>();
            await func(service);
        }

        Task.Run(Function);
    }
}