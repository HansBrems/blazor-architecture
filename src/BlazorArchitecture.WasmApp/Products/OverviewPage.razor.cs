using BlazorArchitecture.WasmApp.Products.Shared.Models;
using BlazorArchitecture.WasmApp.Products.Shared.Services;
using BlazorArchitecture.WasmApp.Shared.Components;
using BlazorArchitecture.WasmApp.Shared.Components.Dialogs.Confirmation;
using BlazorArchitecture.WasmApp.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Products;

public partial class OverviewPage : ComponentBase
{
    [Inject] public IDialogService DialogService { get; set; } = null!;
    [Inject] public IProductApiService ProductApiService { get; init; } = null!;

    private IEnumerable<Product> _products = [];
    
    protected override Task OnInitializedAsync()
    {
        _products = ProductApiService.GetProducts();
        return Task.CompletedTask;
    }
    
    private async Task Delete()
    {
        var result = await DialogService.ShowConfirmationDialog("Delete", "Message", options =>
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
    
    private void NavigateToDetailPage()
    {
        Console.WriteLine("Navigating to detail page");
    }
}