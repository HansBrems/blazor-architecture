namespace BlazorArchitecture.Gateway.Startup;

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
                    .WithOrigins("https://localhost:4321")
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