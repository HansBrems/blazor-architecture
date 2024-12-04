using BlazorArchitecture.WasmApp.Products.Shared.Models;

namespace BlazorArchitecture.WasmApp.Products.Shared.Services;

public class ProductApiService : IProductApiService
{
    private static List<Product> _products =
    [
        new Product { Id = 1, Name = "Playstation", Price = 500 },
        new Product { Id = 2, Name = "Fridge", Price = 800 },
        new Product { Id = 3, Name = "Coffee Machine", Price = 1300 }
    ];

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}