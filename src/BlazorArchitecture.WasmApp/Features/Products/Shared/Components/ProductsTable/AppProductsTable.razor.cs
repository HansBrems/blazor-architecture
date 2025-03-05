using BlazorArchitecture.WasmApp.Features.Products.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Features.Products.Shared.Components.ProductsTable;

public partial class AppProductsTable : ComponentBase
{
    [Parameter]
    public IEnumerable<Product> Products { get; set; } = [];
    
    [Parameter]
    public EventCallback<int> OnRowClick { get; set; }
    
    private async void HandleRowClick(TableRowClickEventArgs<Product> args)
    {
        if (args.Item == null) return;
        await OnRowClick.InvokeAsync(args.Item.Id);
    }
}