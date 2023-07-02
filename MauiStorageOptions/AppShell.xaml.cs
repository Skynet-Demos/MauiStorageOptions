using MauiStorageOptions.ViewModels;

namespace MauiStorageOptions;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();

		// get value from Preferences
		var rememberMe = Preferences.Default.Get<bool>(Constants.RememberMe, false);
		StorageOptionsShell.CurrentItem = rememberMe ? HomeViewItem : LoginViewItem;
	}
}
