using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="services"></param>
public class ChainConfiguratorImplementation<T>([NotNull] IServiceCollection services) : IChainConfigurator<T>
    where T : class
{
    private readonly Type _interfaceType = typeof(T);
    private readonly IServiceCollection _services = services ?? throw new ArgumentNullException(nameof(services));
    private readonly List<Type> _types = new();

    /// <inheritdoc />
    public IChainConfigurator<T> Add<TImplementation>()
        where TImplementation : T
    {
        var type = typeof(TImplementation);

        _types.Add(type);

        return this;
    }

    /// <inheritdoc />
    public void Configure()
    {
        if (_types.Count == 0)
        {
            throw new InvalidOperationException($"No implementation defined for {_interfaceType.Name}");
        }

        foreach (var type in _types)
        {
            ConfigureType(type);
        }
    }

    /// <inheritdoc />
    public void ConfigureType([NotNull] Type currentType)
    {
        if (currentType == null)
        {
            throw new ArgumentNullException(nameof(currentType));
        }

        // gets the next type, as that will be injected in the current type
        var nextType = _types.SkipWhile(x => x != currentType).SkipWhile(x => x == currentType).FirstOrDefault();

        // Makes a parameter expression, that is the IServiceProvider x 
        var parameter = Expression.Parameter(typeof(IServiceProvider), "x");

        // get constructor with highest number of parameters. Ideally, there should be only 1 constructor, but better be safe.
        var ctor = currentType.GetConstructors().OrderByDescending(x => x.GetParameters().Length).First();

        // for each parameter in the constructor
        var ctorParameters = ctor.GetParameters().Select(p =>
                                                         {
                                                             // check if it implements the interface. That's how we find which parameter to inject the next handler.
                                                             if (!_interfaceType.IsAssignableFrom(p.ParameterType))
                                                             {
                                                                 // this is a parameter we don't care about, so we just ask GetRequiredService to resolve it for us 
                                                                 return (Expression)Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService",
                                                                     new[] { p.ParameterType }, parameter);
                                                             }

                                                             if (nextType is null)
                                                             {
                                                                 // if there's no next type, current type is the last in the chain, so it just receives null
                                                                 return Expression.Constant(null, _interfaceType);
                                                             }

                                                             // if there is, then we call IServiceProvider.GetRequiredService to resolve next type for us
                                                             return Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService", new[] { nextType },
                                                                 parameter);
                                                         });

        // cool, we have all of our constructors parameters set, so we build a "new" expression to invoke it.
        var body = Expression.New(ctor, ctorParameters.ToArray());

        // if current type is the first in our list, then we register it by the interface, otherwise by the concrete type
        var first = _types[0] == currentType;
        var resolveType = first ? _interfaceType : currentType;
        var expressionType = Expression.GetFuncType(typeof(IServiceProvider), resolveType);

        // finally, we can build our expression
        var expression = Expression.Lambda(expressionType, body, parameter);

        // compile it
        var compiledExpression = (Func<IServiceProvider, object>)expression.Compile();

        // and register it in the services collection as transient
        _services.AddTransient(resolveType, compiledExpression);
    }
}