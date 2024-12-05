using BlazorArchitecture.WasmApp.Products.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Products.Shared.Components;

public partial class ProductsTable : ComponentBase
{
    [Parameter] public IEnumerable<Product> Products { get; set; } = [];
    
    [Parameter] public EventCallback<int> OnRowClick { get; set; }
    
    private async void HandleRowClick(TableRowClickEventArgs<Product> args)
    {
        if (args.Item == null) return;
        await OnRowClick.InvokeAsync(args.Item.Id);
    }
}