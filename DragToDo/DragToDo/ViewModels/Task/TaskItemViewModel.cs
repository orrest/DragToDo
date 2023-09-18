using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;

namespace DragToDo.ViewModels;

/// <summary>
/// Tasks => Steps => DroppedItems
/// </summary>
public class TaskItemViewModel : ViewModelBase
{
    public ObservableCollection<StepItemViewModel> StepItems { get; private set; }
        = new ObservableCollection<StepItemViewModel>();

    private bool isFinished;
    public bool IsFinished
    {
        get { return isFinished; }
        set { isFinished = value; this.RaisePropertyChanged(); }
    }

    private string description = string.Empty;
    public string Description
    {
        get { return description; }
        set { description = value; this.RaisePropertyChanged(); }
    }

    private bool isExpanded;
    public bool IsExpanded
    {
        get { return isExpanded; }
        set { isExpanded = value; this.RaisePropertyChanged(); }
    }
}

public class StepItemViewModel : ViewModelBase
{
    public ObservableCollection<DroppedItemViewModel> DroppedItems { get; private set; }
        = new ObservableCollection<DroppedItemViewModel>();

    private bool isFinished;
    public bool IsFinished
    {
        get { return isFinished; }
        set { isFinished = value; this.RaisePropertyChanged(); }
    }

    private bool isExpanded;
    public bool IsExpanded
    {
        get { return isExpanded; }
        set { isExpanded = value; this.RaisePropertyChanged(); }
    }

    private string description = string.Empty;
    public string Description
    {
        get { return description; }
        set { description = value; this.RaisePropertyChanged(); }
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