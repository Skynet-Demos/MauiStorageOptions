using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}