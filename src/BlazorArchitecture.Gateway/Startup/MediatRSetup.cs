using BlazorArchitecture.Gateway.Products.GetProduct;
using BlazorArchitecture.Gateway.Shared;

namespace BlazorArchitecture.Gateway.Startup;

public static class MediatRSetup
{
    public static WebApplicationBuilder AddMediatRSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(options =>
        {
            options
                .AddOpenBehavior(typeof(ErrorInterceptor<,>))
                .RegisterServicesFromAssemblies(
                    typeof(GetProductQuery).Assembly,
                    typeof(GetProductQueryHandler).Assembly
                );
        });

        return builder;
    }
}
