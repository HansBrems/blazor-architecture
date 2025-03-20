using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArchitecture.Gateway.Products.GetProduct;

public static class GetProductEndpoint
{
    public static RouteGroupBuilder MapGetProduct(this RouteGroupBuilder builder)
    {
        builder
            .MapGet("{id:int}", GetProduct)
            .WithName("Product");

        return builder;
    }
    
    private static async Task<IResult> GetProduct([FromServices] IMediator mediator, int id)
    {
        var result = await mediator.Send(new GetProductQuery { Id = id });
        return result.Match(Results.Ok, error => Results.Problem(error.ErrorMessage));
    }
}