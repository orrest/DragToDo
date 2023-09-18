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
        // 拖动源数据链接到目标位置
        e.DragEffects = e.DragEffects & (DragDropEffects.Link);
        
        if (e.Data.Contains(DataFormats.Files))
        {
            // 可以选中多个同时拖动
            var files = e.Data.GetFiles();
            
            if (files == null) return;

            var rectangle = (Control)e.Source;

            // TODO 改成附加属性会更好
            if (rectangle == null)
            {
                throw new ArgumentException("不应发生, UI或有改动");
            }

            var panel = rectangle.Parent;
            if (panel == null)
            {
                throw new ArgumentException("不应发生, UI或有改动");
            }

            var stepDataContext = (StepItemViewModel) panel.DataContext;
            if (stepDataContext == null)
            {
                throw new ArgumentException("不应发生, UI或有改动");
            }

            // 根据交互添加数据到VM中
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
