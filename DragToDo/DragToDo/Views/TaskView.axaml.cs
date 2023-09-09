using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using ReactiveUI;

namespace DragToDo;

public partial class TaskView : ReactiveUserControl<TaskViewModel>
{
    public TaskView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}