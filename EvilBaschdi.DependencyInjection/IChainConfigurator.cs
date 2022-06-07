namespace EvilBaschdi.DependencyInjection;

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
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    void Configure();

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    void ConfigureType(Type currentType);
}