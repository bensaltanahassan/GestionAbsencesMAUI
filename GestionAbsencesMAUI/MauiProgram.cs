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
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();

            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterPageViewModel>();

            builder.Services.AddTransient<MainPageChoices>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<StudentPage>();
            builder.Services.AddTransient<StudentPageViewModel>();

            builder.Services.AddTransient<InfoPage>();
            builder.Services.AddTransient<InfoPageViewModel>();

            builder.Services.AddTransient<SearchPage>();
            builder.Services.AddTransient<SearchPageViewModel>();

            builder.Services.AddTransient<AbsencesPage>();
            builder.Services.AddTransient<AbsencesPageViewModel>();





           


            return builder.Build();
        }
    }
}
