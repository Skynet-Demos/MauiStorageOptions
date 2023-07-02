using CommunityToolkit.Maui;
using MauiStorageOptions.Repositories;
using MauiStorageOptions.ViewModels;
using MauiStorageOptions.Views;
using Microsoft.Extensions.Logging;

namespace MauiStorageOptions;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // register DI for Views and ViewModels

        builder.Services.AddSingleton<LoginView>();
		builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<HomeView>();
        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddSingleton<CreateTodoView>();
        builder.Services.AddSingleton<CreateTodoViewModel>();

        builder.Services.AddSingleton<EditTodoView>();
        builder.Services.AddSingleton<EditTodoViewModel>();

        builder.Services.AddSingleton<LogsView>();
        builder.Services.AddSingleton<LogsViewModel>();

		// setup DB
		var dbName = "todo.db3";
		var dbPath = FileAccessHelper.GetLocalFilePath(dbName);
		builder.Services.AddSingleton<TodoRepository>(s => ActivatorUtilities.CreateInstance<TodoRepository>(s, dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
