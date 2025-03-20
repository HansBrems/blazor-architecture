using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;
using MediatR;

namespace BlazorArchitecture.Gateway.Products.GetProducts;

public class GetProductsQuery : IRequest<Result<IEnumerable<Product>>>
{
}