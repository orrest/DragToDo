using DragToDo.Navigation;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace DragToDo.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    // The Router associated with this Screen.
    // Required by the IScreen interface.
    public RoutingState Router { get; } = new RoutingState();

    private ObservableCollection<MainMenuItem> menu = new ObservableCollection<MainMenuItem>();
    public ObservableCollection<MainMenuItem> Menu 
    {
        get { return menu; }
        set { menu = value; this.RaisePropertyChanged(nameof(Menu)); } 
    }

    public MainViewModel()
    {
        CreateMenu();
    }

    private void CreateMenu()
    {
        Menu.Add(new MainMenuItem("Tasks", Router, typeof(TaskViewModel), this));
        Menu.Add(new MainMenuItem("Countdowns", Router, typeof(CountdownViewModel), this));
        Menu.Add(new MainMenuItem("Memos", Router, typeof(MemoViewModel), this));
    }
}

public class MainMenuItem : MenuItem
{
    public MainMenuItem(
        string name,
        RoutingState router,
        Type type,
        IScreen screen) : base(name, router, type, screen)
    {
    }
}