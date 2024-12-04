using BlazorArchitecture.WasmApp.Products.Shared.Models;

namespace BlazorArchitecture.WasmApp.Products.Shared.Services;

public interface IProductApiService
{
    IEnumerable<Product> GetProducts();
}