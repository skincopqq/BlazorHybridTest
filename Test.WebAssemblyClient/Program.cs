using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Test.WebAssemblyClient.Services;
using Blazored.LocalStorage;
using Test.FrontShared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Test.FrontShared;
using Test.Maui.Shared.Services;

namespace Test.WebAssemblyClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

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

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IStorageWrapper, LocalStorageWrapper>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddAuthorizationCore();


            await builder.Build().RunAsync();
        }
    }
}
