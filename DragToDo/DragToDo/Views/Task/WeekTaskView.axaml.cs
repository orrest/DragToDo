using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using ReactiveUI;

namespace DragToDo.Views;

public partial class WeekTaskView : ReactiveUserControl<WeekTaskViewModel>
{
    public WeekTaskView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
