using BlazorArchitecture.BackEnd.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArchitecture.BackEnd.Products.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet(Name = "GetProducts")]
    public IActionResult Get()
    {
        var products = new []
        {
            new Product { ProductId = 1, Name = "Plaaystation", Price = 500 },
            new Product { ProductId = 2, Name = "Fridge", Price = 800 },
            new Product { ProductId = 3, Name = "Coffee Machine", Price = 1300 }
        };

        return Ok(products);
    }

    [HttpGet("businessError", Name = "GetBusinessError")]
    public IActionResult GetBusinessError()
    {
        return Problem("This is a business error", statusCode: 400);
    }
    
    [HttpGet("technicalError", Name = "GetTechnicalError")]
    public IActionResult GetTechnicalError()
    {
        return Problem("This is a technical error", statusCode: 500);
    }
}