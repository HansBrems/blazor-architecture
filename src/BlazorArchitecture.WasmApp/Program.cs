using BlazorArchitecture.WasmApp.Features.Products.Overview;
using BlazorArchitecture.WasmApp.Features.Products.Shared.Services;
using BlazorArchitecture.WasmApp.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

namespace BlazorArchitecture.WasmApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services
            .AddMudServices()
            .AddSingleton<ISnackbar, SnackbarService>()
            .AddTransient<HttpErrorHandler>()
            .AddTransient<OverviewPageViewModel>()
            .AddHttpClient<IProductApiService, ProductApiService>()
                .AddHttpMessageHandler<HttpErrorHandler>();
        
        await builder.Build().RunAsync();
    }
}