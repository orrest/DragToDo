using System.Collections.ObjectModel;

namespace DragToDo.Navigation;

public interface IMenuView<T> where T : MenuItem
{
    ObservableCollection<T> Menu { get; set; }

    void CreateMenu();
}
