using BlazorArchitecture.WasmApp.Products.Shared.Models;
using BlazorArchitecture.WasmApp.Products.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Products;

public partial class OverviewPage : ComponentBase
{
    [Inject] public IProductApiService ProductApiService { get; init; } = null!;

    private IEnumerable<Product> _products = [];
    
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(0);

        _products = ProductApiService.GetProducts();
    }
}