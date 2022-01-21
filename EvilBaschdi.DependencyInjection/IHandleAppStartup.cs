using System;
using System.Threading.Tasks;

namespace EvilBaschdi.DependencyInjection;

/// <summary>
/// </summary>
public interface IHandleAppStartup
{
    /// <summary>
    /// </summary>
    Task<T> ValueForAsync<T>(IServiceProvider serviceProvider);
    //where TWindow : Window;
}