using Splat;

namespace DragToDo.DependencyInjection;

public class Bootstrapper
{
    /// <summary>
    /// 注册所有所需的服务
    /// </summary>
    /// <param name="services">Locator.CurrentMutable 用于注册和解析服务的容器引用</param>
    /// <param name="resolver">Locator.Current 只读的仅用于解析服务的容器引用</param>
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        ViewModelsBootstrapper.RegisterViewModels(services, resolver);
    }
}
