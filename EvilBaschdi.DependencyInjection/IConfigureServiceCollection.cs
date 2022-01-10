using EvilBaschdi.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.DependencyInjection
{
    /// <inheritdoc />
    public interface IConfigureServiceCollection : IRunFor<IServiceCollection>
    {

    }
}