using EvilBaschdi.Core;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.DependencyInjection;

/// <inheritdoc />
public class HostInstance : IHostInstance
{
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    IHost IValue<IHost>.Value { get; }

    IHost IWritableValue<IHost>.Value { get; set; }
}