using BlazorArchitecture.WasmApp.Products.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Products.Shared.Components;

public partial class ProductsTable : ComponentBase
{
    [Parameter] public IEnumerable<Product> Products { get; set; } = [];
}