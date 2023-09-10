using ReactiveUI;
using System;

namespace DragToDo
{
    public class AppViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
        {
            var fullName = viewModel.GetType().FullName;
            if (fullName is null)
            {
                throw new InvalidOperationException("Full name for type was not found");
            }

            var name = fullName.Replace("ViewModel", "View");

            var type = Type.GetType(name);
            if (type is null)
            {
                throw new InvalidOperationException($"Type {name} was not found");
            }

            return Activator.CreateInstance(type) as IViewFor;
        }
    }
}
