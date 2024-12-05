using BlazorArchitecture.WasmApp.Products.Shared.Models;
using BlazorArchitecture.WasmApp.Products.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorArchitecture.WasmApp.Products;

public partial class OverviewPage : ComponentBase
{
    [Inject] public IProductApiService ProductApiService { get; init; } = null!;

    private IEnumerable<Product> _products = [];
    private bool _isOverlayVisible = false;
    private int? _selectedProductId;
    
    protected override Task OnInitializedAsync()
    {
        _products = ProductApiService.GetProducts();
        return Task.CompletedTask;
    }

    private void OnOverlayClosed()
    {
        Console.WriteLine("It's closed!");
    }

    private void ToggleOverlay(int productId)
    {
        _selectedProductId = productId;
        _isOverlayVisible = true;
    }
}