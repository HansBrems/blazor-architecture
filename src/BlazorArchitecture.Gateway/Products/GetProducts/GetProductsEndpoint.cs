using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArchitecture.Gateway.Products.GetProducts;

public static class GetProductsEndpoint
{
    public static RouteGroupBuilder MapGetProducts(this RouteGroupBuilder builder)
    {
        builder
            .MapGet("", GetProducts)
            .WithName("Products");

        return builder;
    }

    private static async Task<IResult> GetProducts([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetProductsQuery());
        return result.Match(Results.Ok, error => Results.Problem(error.ErrorMessage));
    }
}