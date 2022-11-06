using Lounge.ViewModels;
using CommunityToolkit.Maui;
using Lounge.Domain.Configuration;

namespace Lounge;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<Register>();

        builder.Services.AddTransient<AccountSetupViewModel>();
        builder.Services.AddTransient<AccountSetup>();

        builder.Services.AddDomain();
        return builder.Build();
    }
}