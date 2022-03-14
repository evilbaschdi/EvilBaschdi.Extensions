using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <summary>
/// </summary>
public static class ChainConfigurator
{
    /// <summary>
    /// </summary>
    /// <param name="services"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainConfigurator<T> Chain<T>(this IServiceCollection services)
        where T : class
    {
        return new ChainConfiguratorImplementation<T>(services);
    }
}