using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Enrichment;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Prism;
using Prism.Container.DryIoc;
using Prism.Ioc;

namespace Project2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp
                .CreateBuilder()
                .UseMauiApp<App>()
                .UseShiny()
                .UseMauiCommunityToolkit()
                .UsePrism(
                    new DryIocContainerExtension(),
                    prism => prism.CreateWindow("NavigationPage/MainPage")
                )
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Configuration.AddJsonPlatformBundle();
#if DEBUG
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.AddDebug();
#endif
            builder.Services.AddConnectivity();
            builder.Services.AddBattery();
            builder.Services.AddGeofencing<Project2.Delegates.MyGeofenceDelegate>();

            builder.Services.AddScoped<BaseServices>();
            builder.Services.RegisterForNavigation<MainPage, MainViewModel>();
            var app = builder.Build();

            return app;
        }
    }
}