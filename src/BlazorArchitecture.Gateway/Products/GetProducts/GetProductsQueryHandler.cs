using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;
using MediatR;

namespace BlazorArchitecture.Gateway.Products.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<IEnumerable<Product>>>
{
    public async Task<Result<IEnumerable<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await FetchProducts();
        return Result.Success(products);
    }

    private async Task<IEnumerable<Product>> FetchProducts()
    {
        await Task.Delay(100);
        return [
            new Product { ProductId = 1, Name = "Playstation", Price = 500 },
            new Product { ProductId = 2, Name = "Fridge", Price = 800 },
            new Product { ProductId = 3, Name = "Coffee Machine", Price = 1300 }
        ];
    }
}