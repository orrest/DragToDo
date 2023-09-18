using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using DragToDo.Helpers;
using ReactiveUI;
using System;
using Avalonia.Controls;

namespace DragToDo.Views;

public partial class WeekTaskView : ReactiveUserControl<WeekTaskViewModel>
{
    public WeekTaskView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);

        AddHandler(DragDrop.DropEvent, Drop);
    }

    public void Drop(object? sender, DragEventArgs e)
    {
        // �϶�Դ�������ӵ�Ŀ��λ��
        e.DragEffects = e.DragEffects & (DragDropEffects.Link);
        
        if (e.Data.Contains(DataFormats.Files))
        {
            // ����ѡ�ж��ͬʱ�϶�
            var files = e.Data.GetFiles();
            
            if (files == null) return;

            var rectangle = (Control)e.Source;

            // TODO �ĳɸ������Ի����
            if (rectangle == null)
            {
                throw new ArgumentException("��Ӧ����, UI���иĶ�");
            }

            var panel = rectangle.Parent;
            if (panel == null)
            {
                throw new ArgumentException("��Ӧ����, UI���иĶ�");
            }

            var stepDataContext = (StepItemViewModel) panel.DataContext;
            if (stepDataContext == null)
            {
                throw new ArgumentException("��Ӧ����, UI���иĶ�");
            }

            // ���ݽ���������ݵ�VM��
            foreach (var fileInfo in files)
            {
                var path = fileInfo.Path.LocalPath.ToString();
                var name = fileInfo.Name;
                var icon = name.GetIcon();
                var newDropped = new DroppedItemViewModel()
                {
                    Icon = icon.ToString(),
                    Path = path,
                    Name = name
                };
                stepDataContext.DroppedItems.Add(newDropped);
            }
        }
        else if (e.Data.Contains(DataFormats.Text))
        {

        }
    }
}
