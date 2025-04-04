using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Test.FrontShared.Services;
using Test.FrontShared;
using Test.Maui.Shared.Services;
using Test.WpfClient.Services;

namespace Test.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IFormFactor, FormFactor>();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddBlazorWebViewDeveloperTools();

            serviceCollection.AddTransient<AuthHandler>();
            serviceCollection.AddScoped(sp =>
            {
                var authHandler = sp.GetRequiredService<AuthHandler>();
                authHandler.InnerHandler = new HttpClientHandler();
                return new HttpClient(authHandler)
                {
                    BaseAddress = new Uri("https://localhost:7129")
                };
            });

            serviceCollection.AddScoped<IStorageWrapper, SettingsStorageWrapper>();
            serviceCollection.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            serviceCollection.AddAuthorizationCore();

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }

}
