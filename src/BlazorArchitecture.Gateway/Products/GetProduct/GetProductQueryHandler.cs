using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;
using MediatR;

namespace BlazorArchitecture.Gateway.Products.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await FetchProduct();
        return Result.Success(product);
    }

    private async Task<Product> FetchProduct()
    {
        await Task.Delay(100);
        
        return new Product
        {
            ProductId = 1,
            Name = "Table",
            Price = 50
        };
    }
}