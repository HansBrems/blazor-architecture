using BlazorArchitecture.Gateway.Products.GetProduct;
using BlazorArchitecture.Gateway.Products.GetProducts;

namespace BlazorArchitecture.Gateway.Products;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var productGroup = app
            .MapGroup("api/products")
            .WithName("Products")
            .WithDisplayName("Productos")
            .WithTags("Products");

        productGroup
            .MapGetProduct()
            .MapGetProducts();
    }
}