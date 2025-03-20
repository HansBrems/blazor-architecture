using BlazorArchitecture.Gateway.Contracts;
using BlazorArchitecture.Gateway.Shared;
using MediatR;

namespace BlazorArchitecture.Gateway.Products.GetProduct;

public class GetProductQuery : IRequest<Result<Product>>
{
    public int Id { get; set; }
}