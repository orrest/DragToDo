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
    /// Header��������
    /// </summary>
    public static readonly StyledProperty<string> TextProperty = 
        AvaloniaProperty.Register<CheckExpander, string>(nameof(Text), defaultValue: string.Empty);

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// �Ƿ�չ��
    /// </summary>
    public static readonly StyledProperty<bool> IsExpandedProperty =
            AvaloniaProperty.Register<CheckExpander, bool>(nameof(CheckExpander), defaultValue: false);

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    /// �Ƿ�Checked
    /// </summary>
    public static readonly StyledProperty<bool> IsCheckedProperty =
            AvaloniaProperty.Register<CheckExpander, bool>(nameof(CheckExpander), defaultValue: false);

    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    /// <summary>
    /// ���ڿؼ��ڲ�����Checked�仯
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
