using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions.Views;

public partial class CreateTodoView : ContentPage
{
	public CreateTodoView(CreateTodoViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}