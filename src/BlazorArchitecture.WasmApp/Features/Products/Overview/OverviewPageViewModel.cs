using BlazorArchitecture.WasmApp.Features.Products.Shared.Models;
using BlazorArchitecture.WasmApp.Features.Products.Shared.Services;
using BlazorArchitecture.WasmApp.Shared.Components.ConfirmationDialog;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Features.Products.Overview;

public class OverviewPageViewModel(IDialogService dialogService, IProductApiService productApiService)
{
    public IEnumerable<Product> Products { get; set; } = [];
    
    public async Task Initialize()
    {
        Products = await productApiService.GetProducts();
    }
    
    public async Task Delete()
    {
        var result = await dialogService.ShowConfirmationDialog("Delete", "Message", options =>
        {
            options.ConfirmationType = ConfirmationType.Danger;
        });
        
        var message = "No result";

        if (result != null)
        {
            message = result.Canceled
                ? "The dialog was cancelled"
                : $"Result from the dialog {result.Data}";            
        }
        
        Console.WriteLine(message);
    }
    
    public void NavigateToDetailPage()
    {
        Console.WriteLine("Navigating to detail page");
    }
}