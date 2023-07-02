using MauiStorageOptions.Repositories;
using MauiStorageOptions.Views;

namespace MauiStorageOptions;

public partial class App : Application
{
	public static TodoRepository TodoRepository { get; private set; }

	public App(TodoRepository todoRepository)
	{
		InitializeComponent();

		// register routes
		Routing.RegisterRoute(nameof(EditTodoView), typeof(EditTodoView));

		MainPage = new AppShell();

		TodoRepository = todoRepository;
	}
}
