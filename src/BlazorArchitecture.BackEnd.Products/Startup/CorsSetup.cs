namespace BlazorArchitecture.BackEnd.Products.Startup;

public static class CorsSetup
{
    private const string BlazorAppPolicy = "BlazorAppPolicy";
    
    public static WebApplicationBuilder AddCorsSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(BlazorAppPolicy, policyBuilder =>
            {
                policyBuilder
                    .WithOrigins("https://localhost:4040")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        return builder;
    }

    public static void UseCorsSetup(this IApplicationBuilder app)
    {
        app.UseCors(BlazorAppPolicy);
    }
}