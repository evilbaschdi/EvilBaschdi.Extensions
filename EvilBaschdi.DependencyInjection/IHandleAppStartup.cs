using System;
using EvilBaschdi.Core;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public interface IHandleAppStartup<TOut> : IValueForAsync<IServiceProvider, TOut>
{
}