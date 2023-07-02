using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiStorageOptions.Views;

namespace MauiStorageOptions.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    bool rememberMe;

    [RelayCommand]
    public async void Login()
    {
        // Validate user credentials (assuming user is authorized)

        await Logger.WriteLogAsync("User has logged in");

        if (RememberMe)
        {
            await Logger.WriteLogAsync("User opted to save his/her identity");
        }

        // set user choice in Preferences
        Preferences.Default.Set(Constants.RememberMe, RememberMe);

        // set user credentials in Secure Storage
        await SecureStorage.Default.SetAsync(Constants.Username, Username);
        await SecureStorage.Default.SetAsync(Constants.AuthenticationKey, "Some auth key for api calls");

        await Logger.WriteLogAsync("Auth Key has been stored securely in SecureStorage");

        await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
    }
}
