using System.Text.Json.Serialization;
using BlazorArchitecture.Gateway.Products;
using BlazorArchitecture.Gateway.Startup;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.AddCorsSetup();
builder.AddMediatRSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Blazor Architecture Gateway"));
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Blazor Architecture Gateway")
            .WithTheme(ScalarTheme.None)
            //.WithDefaultHttpClient(ScalarTarget.CSharp)
            .WithModels(false)
            .WithClientButton(false)
            .WithDarkMode(false)
            .WithDarkModeToggle(false);

        options.HiddenClients = true;
       
    });
}

app.UseCorsSetup();
app.UseHttpsRedirection();
app.MapProductEndpoints();
app.Run();