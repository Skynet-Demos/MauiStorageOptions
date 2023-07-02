using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions.Views;

public partial class LogsView : ContentPage
{
	LogsViewModel viewModel;

	public LogsView(LogsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetLogs();
    }
}