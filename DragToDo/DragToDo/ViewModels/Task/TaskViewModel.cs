using DragToDo.Navigation;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace DragToDo.ViewModels;

public class TaskViewModel : ViewModelBase, IRoutableViewModel, IScreen, IMenuView<TaskMenuItem>
{
    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    public RoutingState Router { get; } = new RoutingState();

    private ObservableCollection<TaskMenuItem> menu = new ObservableCollection<TaskMenuItem>();
    public ObservableCollection<TaskMenuItem> Menu
    {
        get { return menu; }
        set { menu = value; this.RaisePropertyChanged(nameof(Menu)); }
    }

    public TaskViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        CreateMenu();
    }

    public void CreateMenu()
    {
        Menu.Add(new TaskMenuItem("Week", Router, typeof(WeekTaskViewModel), this));
        Menu.Add(new TaskMenuItem("Month", Router, typeof(MonthTaskViewModel), this));
        Menu.Add(new TaskMenuItem("Year", Router, typeof(YearTaskViewModel), this));
    }
}

public class TaskMenuItem : MenuItem
{
    public TaskMenuItem(
        string name,
        RoutingState router,
        Type viewModelType,
        IScreen screen) : base(name, router, viewModelType, screen)
    {
    }
}