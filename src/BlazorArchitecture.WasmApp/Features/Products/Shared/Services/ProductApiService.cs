using System.Net.Http.Json;
using BlazorArchitecture.WasmApp.Features.Products.Shared.Models;

namespace BlazorArchitecture.WasmApp.Features.Products.Shared.Services;

public class ProductApiService(HttpClient httpClient): IProductApiService
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        try
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:4040/api/products") ?? [];
        }
        catch (Exception e)
        {
            return [];
        }
    }
}