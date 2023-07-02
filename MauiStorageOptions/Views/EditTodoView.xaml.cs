using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions.Views;

public partial class EditTodoView : ContentPage
{
	public EditTodoView(EditTodoViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}