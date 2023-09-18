using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace DragToDo.ViewModels;

public class WeekTaskViewModel : ViewModelBase, IRoutableViewModel
{
    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    // Task => Step => DroppedItems
    public ObservableCollection<TaskItemViewModel> WeekTasks { get; private set; }
        = new ObservableCollection<TaskItemViewModel>();

    public WeekTaskViewModel()
    {
        // test data
        var task = new TaskItemViewModel()
        {
            IsFinished = false,
            IsExpanded = true,
            Description = "测试1",
        };
        task.StepItems.Add(new StepItemViewModel()
        {
            IsFinished = false,
            IsExpanded = true,
            Description = "测试1",
        });
        WeekTasks.Add(task);
    }

    public WeekTaskViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}

