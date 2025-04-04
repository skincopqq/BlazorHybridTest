using Microsoft.Extensions.Logging;
using Test.FrontShared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Test.FrontShared;
using Test.Maui.Shared.Services;
using Test.Maui.Services;

namespace Test.Maui;

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
            });

        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        builder.Services.AddTransient<AuthHandler>();
        builder.Services.AddScoped(sp =>
        {
            var authHandler = sp.GetRequiredService<AuthHandler>();
            authHandler.InnerHandler = new HttpClientHandler();
            return new HttpClient(authHandler)
            {
                BaseAddress = new Uri("https://localhost:7129")
            };
        });

        builder.Services.AddScoped<IStorageWrapper, SecureStorageWrapper>();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        builder.Services.AddAuthorizationCore();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
