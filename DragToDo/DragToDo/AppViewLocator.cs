using DragToDo.ViewModels;
using ReactiveUI;
using System;

namespace DragToDo
{
    public class AppViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) 
            => viewModel switch
            {
                TaskViewModel context => new TaskView() { DataContext = context },
                _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
            };
    }
}
