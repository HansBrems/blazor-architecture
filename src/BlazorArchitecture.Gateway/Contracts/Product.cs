namespace BlazorArchitecture.Gateway.Contracts;

public class Product
{
    public required int ProductId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; init; }
}