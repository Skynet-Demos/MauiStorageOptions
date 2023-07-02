using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions.Views;

public partial class HomeView : ContentPage
{
	HomeViewModel viewModel;

	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.RefreshUsername();
		viewModel.GetTodoItemsCommand.Execute(null);
    }
}