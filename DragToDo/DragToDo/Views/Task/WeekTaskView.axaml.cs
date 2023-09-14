using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DragToDo.ViewModels;
using DragToDo.Helpers;
using Material.Icons;
using ReactiveUI;
using System;

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

            var context = this.DataContext as WeekTaskViewModel;
            if (context == null)
            {
                throw new Exception("ViewModel's type not right.");
            }

            // ���ݽ���������ݵ�VM��
            foreach (var fileInfo in files)
            {
                var path = fileInfo.Path.LocalPath.ToString();
                var name = fileInfo.Name;
                var icon = name.GetIcon();
                context.DroppedItems.Add(new DroppedItemViewModel()
                {
                    Icon = icon.ToString(),
                    Path = path,
                    Name = name
                });
            }
        }
        else if (e.Data.Contains(DataFormats.Text))
        {

        }
    }
}
