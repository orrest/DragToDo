using ReactiveUI;
using System;

namespace DragToDo.ViewModels;

public class MonthTaskViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen { get; }

    public MonthTaskViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
