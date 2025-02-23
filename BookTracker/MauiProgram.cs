using BookTracker.DataAccess;
using Microsoft.Extensions.Logging;

namespace BookTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");
        builder.Services.AddSingleton<IBooksRepository>(s => ActivatorUtilities.CreateInstance<BooksRepository>(s, dbPath));

        return builder.Build();
    }
}