using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiStorageOptions.Models;

namespace MauiStorageOptions.ViewModels;

public partial class CreateTodoViewModel : ObservableObject
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    DateTime duedate;

    public CreateTodoViewModel()
    {
        Duedate = DateTime.Now;
    }

    [RelayCommand]
    public async void Save()
    {
        var todoItem = new Todo
        {
            Title = Title,
            Description = Description,
            Duedate = Duedate,
            Status = TodoStatus.Inprogress.ToString()
        };

        await App.TodoRepository.AddTodoAsync(todoItem);

        await Toast.Make("Todo item has been saved!").Show();
    }
}
