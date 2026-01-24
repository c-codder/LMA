using Microsoft.Extensions.Logging;
using LMA.Data;
using LMA.Interfaces;
using LMA.ViewModels;

namespace LMA
{
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

            // Register services and viewmodels
            builder.Services.AddSingleton<INotesService, NotesDatabase>();
            builder.Services.AddSingleton<NotesBoardViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
