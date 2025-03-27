using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;
using MediatR;

namespace BlazorArchitecture.Gateway.Products.GetProducts;

public class GetProductsQueryHandler(IProductApiService productsApiService)
    : IRequestHandler<GetProductsQuery, Result<IEnumerable<Product>>>
{
    public async Task<Result<IEnumerable<Product>>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var productsTask = productsApiService.GetProducts();
        var businessErrorTask = productsApiService.GetBusinessError();
        await Task.WhenAll(productsTask, businessErrorTask);
        
        if (productsTask.Result.Error != null || businessErrorTask.Result.Error != null)
        {
            return Result.Failure<IEnumerable<Product>>(businessErrorTask.Result.Error);
        }
        
        return Result.Success(productsTask.Result.Payload);
    }
}