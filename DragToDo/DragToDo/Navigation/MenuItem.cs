using DragToDo.DependencyInjection;
using ReactiveUI;
using Splat;
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
        // TODO not return new instance
        return Router.Navigate.Execute((IRoutableViewModel)Locator.Current.GetRequiredService(type));
    }
}
