using Avalonia;
using Avalonia.Controls.Primitives;
using ReactiveUI;
using System.Windows.Input;

namespace DragToDo.Controls;

public class CheckExpander : HeaderedContentControl
{
    public CheckExpander()
    {
        CheckCommand = ReactiveCommand.Create(() =>
        {
            IsChecked = !IsChecked;
        });
    }

    /// <summary>
    /// Header文字内容
    /// </summary>
    public static readonly StyledProperty<string> TextProperty = 
        AvaloniaProperty.Register<CheckExpander, string>(nameof(Text), defaultValue: string.Empty);

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 是否展开
    /// </summary>
    public static readonly StyledProperty<bool> IsExpandedProperty =
            AvaloniaProperty.Register<CheckExpander, bool>(nameof(CheckExpander), defaultValue: false);

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    /// 是否Checked
    /// </summary>
    public static readonly StyledProperty<bool> IsCheckedProperty =
            AvaloniaProperty.Register<CheckExpander, bool>(nameof(CheckExpander), defaultValue: false);

    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    /// <summary>
    /// 用于控件内部控制Checked变化
    /// </summary>
    public static readonly StyledProperty<ICommand> CheckCommandProperty =
            AvaloniaProperty.Register<CheckExpander, ICommand>(nameof(CheckExpander), defaultValue: ReactiveCommand.Create(() =>
            {
                // do nothing.
            }));

    public ICommand CheckCommand
    {
        get => GetValue(CheckCommandProperty);
        private set => SetValue(CheckCommandProperty, value);
    }
}
