using DragToDo.Services.Abstractions;
using DragToDo.Services.Implements;
using DragToDo.ViewModels;
using Splat;

namespace DragToDo.DependencyInjection;

public static class ViewModelsBootstrapper
{
    public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterServices(services, resolver);
        RegisterFactories(services, resolver);
        RegisterCommonViewModels(services, resolver);
        RegisterPlatformSpecificViewModels(services, resolver);
    }

    private static void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<IHttpService>(() => new HttpService());
    }

    private static void RegisterFactories(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }

    private static void RegisterCommonViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register(() => new MainViewModel(resolver.GetRequiredService<IHttpService>()));
    }

    private static void RegisterPlatformSpecificViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }

    private static void RegisterMacViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }
}
