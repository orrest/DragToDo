using DragToDo.Services.Abstractions;
using DragToDo.Services.Implements;
using DragToDo.ViewModels;
using DragToDo.Views;
using ReactiveUI;
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
        services.RegisterLazySingleton(() => new MainViewModel());

        services.RegisterLazySingleton(() => new TaskViewModel());
        services.RegisterLazySingleton(() => new CountdownViewModel());
        services.RegisterLazySingleton(() => new MemoViewModel());

        services.RegisterLazySingleton(() => new WeekTaskViewModel());
        services.RegisterLazySingleton(() => new MonthTaskViewModel());
        services.RegisterLazySingleton(() => new YearTaskViewModel());

    }

    private static void RegisterPlatformSpecificViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }

    private static void RegisterMacViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }
}
