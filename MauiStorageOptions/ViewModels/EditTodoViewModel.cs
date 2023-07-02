using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiStorageOptions.Models;

namespace MauiStorageOptions.ViewModels;

[QueryProperty("Todo", nameof(Models.Todo))]
public partial class EditTodoViewModel : ObservableObject
{
    [ObservableProperty]
    Todo todo;

    [RelayCommand]
    async Task Update()
    {
        await App.TodoRepository.UpdateTodoAsync(Todo);
        await Toast.Make("Todo details are updated!").Show();
    }

    [RelayCommand]
    async Task Delete()
    {
        var confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure to delete this todo?", "OK", "NO");
        if (confirm)
        {
            await App.TodoRepository.DeleteTodoAsync(Todo);
            await GoBack();
        }
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
