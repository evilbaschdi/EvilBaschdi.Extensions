// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global

namespace EvilBaschdi.Core.DependencyInjection;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IChainConfigurator<in T>
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    IChainConfigurator<T> Add<TImplementation>()
        where TImplementation : T;

    /// <summary>
    /// </summary>
    void Configure();

    /// <summary>
    /// </summary>
    void ConfigureType(Type currentType);
}