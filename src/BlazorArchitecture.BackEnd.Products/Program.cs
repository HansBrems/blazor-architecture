using BlazorArchitecture.BackEnd.Products.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.AddCorsSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Blazor Architecture Back End Products"));
}

app.UseCorsSetup();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();