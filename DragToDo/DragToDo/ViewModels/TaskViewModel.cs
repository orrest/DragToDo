using DragToDo.Navigation;
using ReactiveUI;
using System;

namespace DragToDo.ViewModels;

public class TaskViewModel : ViewModelBase, IRoutableViewModel, IScreen
{
    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    public RoutingState Router { get; } = new RoutingState();

    public TaskViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}

public class TaskMenuItem : MenuItem
{
    public TaskMenuItem(
        string name,
        RoutingState router,
        Type type,
        IScreen screen) : base(name, router, type, screen)
    {
    }
}