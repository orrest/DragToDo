using ReactiveUI;
using System;

namespace DragToDo.ViewModels;

public class YearTaskViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen { get; }

    public YearTaskViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
