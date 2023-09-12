using ReactiveUI;
using System;
using System.Reactive;

namespace DragToDo.Navigation;

public abstract class MenuItem
{
    public RoutingState Router { get; }
    public Type ViewModelType { get; }
    public IScreen Screen { get; }
    public string Name { get; set; }
    public ReactiveCommand<Unit, IRoutableViewModel> NavigateCommand { get; }

    public MenuItem(string name, RoutingState router, Type type, IScreen screen)
    {
        Name = name;
        Router = router;
        ViewModelType = type;
        Screen = screen;
        NavigateCommand = ReactiveCommand.CreateFromObservable(Navigate);
    }

    private IObservable<IRoutableViewModel> Navigate()
    {
        var type = ViewModelType;
        var constructor = type.GetConstructor(new Type[] { typeof(IScreen) });
        if (constructor == null)
        {
            throw new InvalidOperationException("被导航到的ViewModel没有IScreen构造函数参数");
        }
        return Router.Navigate.Execute((IRoutableViewModel)constructor.Invoke(new object[] { Screen }));
    }
}
