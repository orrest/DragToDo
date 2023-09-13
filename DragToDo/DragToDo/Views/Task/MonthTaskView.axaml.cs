using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using ReactiveUI;

namespace DragToDo.Views;

public partial class MonthTaskView : ReactiveUserControl<MonthTaskViewModel>
{
    public MonthTaskView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
