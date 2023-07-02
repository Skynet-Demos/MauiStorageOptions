using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiStorageOptions.Models;
using MauiStorageOptions.Views;
using System.Collections.ObjectModel;

namespace MauiStorageOptions.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    string username;

    [ObservableProperty]
    ObservableCollection<Todo> todoItems;

    public HomeViewModel()
    {
        TodoItems = new ObservableCollection<Todo>();
    }

    public async void RefreshUsername()
    {
        // retrieve values from Secure Storgae
        Username = await SecureStorage.Default.GetAsync(Constants.Username);
        await Logger.WriteLogAsync($"Hello, {Username}");
    }

    [RelayCommand]
    public async Task Tap(Todo todo)
    {
        await Shell.Current.GoToAsync($"{nameof(EditTodoView)}",
            new Dictionary<string, object>
            {
                { nameof(Todo), todo }
            });
    }

    [RelayCommand]
    public async Task GetTodoItems()
    {
        var rawData = await App.TodoRepository.GetAllTodosAsync();
        MapToObservableCollection(rawData);
    }

    private void MapToObservableCollection(List<Todo> todos)
    {
        TodoItems.Clear();
        foreach (var item in todos)
        {
            TodoItems.Add(item);
        }
    }
}
