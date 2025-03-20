using BlazorArchitecture.Gateway.Products.GetProduct;

namespace BlazorArchitecture.Gateway.Startup;

public static class MediatRSetup
{
    public static WebApplicationBuilder AddMediatRSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(options =>
        {
            options
                //.AddOpenBehavior(typeof(ErrorBehavior<,>))
                .RegisterServicesFromAssemblies(
                    typeof(GetProductQuery).Assembly,
                    typeof(GetProductQueryHandler).Assembly
                );
        });

        return builder;
    }
}
