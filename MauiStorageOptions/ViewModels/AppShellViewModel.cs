using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiStorageOptions.Views;

namespace MauiStorageOptions.ViewModels;

public partial class AppShellViewModel : ObservableObject
{
    [RelayCommand]
    public async Task Logout()
    {
        var confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure to logout?", "OK", "No");
        if (confirm)
        {
            // clear Preferences and Secure Storage
            Preferences.Default.Clear();
            SecureStorage.Default.RemoveAll();

            await Logger.WriteLogAsync("Preferences and SecureStorage are cleared before user logs out");

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }
    }
}
