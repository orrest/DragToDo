using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia;
using System;
using System.Windows.Input;

namespace DragToDo.Behaviors;


/// <summary>
/// Container class for attached properties. Must inherit from <see cref="AvaloniaObject"/>.
/// </summary>
public class DroppedBehav : AvaloniaObject
{
    /// <summary>
    /// Identifies the <seealso cref="CommandProperty"/> avalonia attached property.
    /// <DoubleTappedBehav, Interactive, ICommand>
    /// Owner, Control(Raise routed event), AP type
    /// </summary>
    /// <value>Provide an <see cref="ICommand"/> derived object or binding.</value>
    public static readonly AttachedProperty<ICommand> CommandProperty
        = AvaloniaProperty.RegisterAttached<DroppedBehav, Interactive, ICommand>(
            "Command", default(ICommand), false, BindingMode.OneTime);

    /// <summary>
    /// <see cref="CommandProperty"/> changed event handler.
    /// </summary>
    private static void HandleCommandChanged(AvaloniaObject element, ICommand commandValue)
    {
        if (element is Interactive interactElem)
        {
            if (commandValue != null)
            {
                // Add non-null value
                interactElem.AddHandler(DragDrop.DropEvent, Handler);
            }
            else
            {
                // remove prev value
                interactElem.RemoveHandler(DragDrop.DropEvent, Handler);
            }
        }

        // local handler fcn
        static void Handler(object s, DragEventArgs e)
        {
            if (s is Interactive interactElem)
            {
                // This is how we get the parameter off of the gui element.
                ICommand commandValue = interactElem.GetValue(CommandProperty);
                commandValue.Execute(e);
            }
        }
    }


    static DroppedBehav()
    {
        CommandProperty.Changed.Subscribe(x =>
            HandleCommandChanged(x.Sender, x.NewValue.GetValueOrDefault<ICommand>()));
    }

    /// <summary>
    /// Accessor for Attached property <see cref="CommandProperty"/>.
    /// </summary>
    public static void SetCommand(AvaloniaObject element, ICommand commandValue)
    {
        element.SetValue(CommandProperty, commandValue);
    }

    /// <summary>
    /// Accessor for Attached property <see cref="CommandProperty"/>.
    /// </summary>
    public static ICommand GetCommand(AvaloniaObject element)
    {
        return element.GetValue(CommandProperty);
    }

}

