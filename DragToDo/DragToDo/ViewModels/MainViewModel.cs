using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace DragToDo.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    // The Router associated with this Screen.
    // Required by the IScreen interface.
    public RoutingState Router { get; } = new RoutingState();

    private ObservableCollection<MenuItem> menu = new ObservableCollection<MenuItem>();
    public ObservableCollection<MenuItem> Menu 
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
        Menu.Add(new MenuItem("Tasks", Router, typeof(TaskViewModel), this));
        Menu.Add(new MenuItem("Countdowns", Router, typeof(CountdownViewModel), this));
        Menu.Add(new MenuItem("Memos", Router, typeof(MemoViewModel), this));
    }
}

public class MenuItem
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