using ReactiveUI;
using System;

namespace DragToDo.ViewModels;

public class WeekTaskViewModel : ViewModelBase, IRoutableViewModel
{
    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    public WeekTaskViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
