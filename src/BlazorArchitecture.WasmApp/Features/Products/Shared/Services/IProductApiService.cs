using BlazorArchitecture.WasmApp.Features.Products.Shared.Models;

namespace BlazorArchitecture.WasmApp.Features.Products.Shared.Services;

public interface IProductApiService
{
    IEnumerable<Product> GetProducts();
}