using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiStorageOptions.ViewModels;

public partial class LogsViewModel : ObservableObject
{
    [ObservableProperty]
    string logs;

    public async Task GetLogs()
    {
        Logs = await Logger.GetLogsAsync();
    }
}
