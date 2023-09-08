using Splat;
using System;

namespace DragToDo.DependencyInjection;

/// <summary>
/// The resolver itself doesn't throw exception if there's no injected instance,
/// and that will be hard for debugging.
/// So, throw exception if there's no required service.
/// </summary>
public static class ReadonlyDependencyResolverExtensions
{
    public static TService GetRequiredService<TService>(this IReadonlyDependencyResolver resolver)
    {
        var service = resolver.GetService<TService>();
        if (service is null)
        {
            throw new InvalidOperationException($"Failed to resolve object of type {typeof(TService)}");
        }

        return service;
    }

    public static object GetRequiredService(this IReadonlyDependencyResolver resolver, Type type)
    {
        var service = resolver.GetService(type);
        if (service is null)
        {
            throw new InvalidOperationException($"Failed to resolve object of type {type}");
        }

        return service;
    }
}
