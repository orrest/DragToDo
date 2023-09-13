using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using ReactiveUI;

namespace DragToDo.Views;

public partial class YearTaskView : ReactiveUserControl<YearTaskViewModel>
{
    public YearTaskView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
