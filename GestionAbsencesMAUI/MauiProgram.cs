using GestionAbsencesMAUI.ViewModels;
using GestionAbsencesMAUI.Views;
using Microsoft.Extensions.Logging;

namespace GestionAbsencesMAUI
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();

            builder.Services.AddSingleton<AbsencesPage>();
            builder.Services.AddSingleton<AbsencesPageViewModel>();


            return builder.Build();
        }
    }
}
