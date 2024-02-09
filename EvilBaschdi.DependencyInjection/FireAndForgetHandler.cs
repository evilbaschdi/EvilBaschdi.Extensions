// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="serviceScopeFactory"></param>
/// <exception cref="ArgumentNullException"></exception>
public class FireAndForgetHandler<T>(
    [NotNull] IServiceScopeFactory serviceScopeFactory) : IFireAndForgetHandler<T>
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));

    /// <inheritdoc />
    public void RunFor([NotNull] Func<T, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        Task.Run(Function);
        return;

        async Task Function()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<T>();
            await func(service);
        }
    }
}