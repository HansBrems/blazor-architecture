using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;

namespace BlazorArchitecture.Gateway.Products;

public interface IProductApiService
{
    Task<Result<IEnumerable<Product>>> GetProducts();
    Task<Result<IEnumerable<Product>>> GetBusinessError();
}

public class ProductApiService(HttpClient httpClient): IProductApiService
{
    public async Task<Result<IEnumerable<Product>>> GetProducts()
    {
        var uri = "https://localhost:4041/api/products";

        try
        {
            var products = await httpClient.GetFromJsonAsync<IEnumerable<Product>>(uri) ?? [];
            return Result.Success(products);
        }
        catch
        {
            return Result.Failure<IEnumerable<Product>>(new Error("Failed to get products", ErrorType.Business));
        }
    }

    public async Task<Result<IEnumerable<Product>>> GetBusinessError()
    {
        var uri = "https://localhost:4041/api/products/businessError";

        try
        {
            var products = await httpClient.GetFromJsonAsync<IEnumerable<Product>>(uri) ?? [];
            return Result.Success(products);
        }
        catch
        {
            return Result.Failure<IEnumerable<Product>>(new Error("Failed to get business error", ErrorType.Business));
        }
    }
}