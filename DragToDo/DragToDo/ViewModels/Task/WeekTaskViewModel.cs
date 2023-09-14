using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;

namespace DragToDo.ViewModels;

public class WeekTaskViewModel : ViewModelBase, IRoutableViewModel
{
    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    public ObservableCollection<DroppedItemViewModel> DroppedItems { get; private set; }
        = new ObservableCollection<DroppedItemViewModel>();

    public WeekTaskViewModel()
    {
        
    }

    public WeekTaskViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}

public class DroppedItemViewModel : ViewModelBase
{
    private string icon = string.Empty;
    public string Icon
    {
        get { return icon; }
        set { icon = value; this.RaisePropertyChanged(); }
    }

    private string path = string.Empty;
    public string Path
    {
        get { return path; }
        set { path = value; this.RaisePropertyChanged(); }
    }

    private string name = string.Empty;
    public string Name
    {
        get { return name; }
        set { name = value; this.RaisePropertyChanged(); }
    }

    public ReactiveCommand<Unit, Unit> OpenFileCommand { get; private set; }

    public DroppedItemViewModel()
    {
        OpenFileCommand = ReactiveCommand.Create(() => {
            new Process
            {
                StartInfo = new ProcessStartInfo(Path)
                {
                    UseShellExecute = true
                }
            }.Start();
        });
    }
}
