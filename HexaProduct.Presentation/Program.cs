using HexaProductCatalog.Application.Services;
using HexaProductCatalog.Domain.Entities;
using HexaProductCatalog.Domain.Interfaces;
using HexaProductCatalog.Presentation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = DependencyInjection.ConfigureServices();

        var productService = serviceProvider.GetRequiredService<IProductService>();
        var productProxy = serviceProvider.GetRequiredService<IProductProxy>();

        var externalProducts = await productProxy.GetExternalProducts();
        foreach (var product in externalProducts)
        {
            Console.WriteLine($"Product from API: {product.Name} - {product.Price}");
            await productService.AddProductAsync(product);
        }

        var allProducts = await productService.GetAllProductsAsync();
        Console.WriteLine("\nAll products from memory:");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"- {product.Name} - {product.Price}");
        }

        Console.WriteLine("\nSearching for products with name 'Apple':");
        var searchResults = await productService.SearchProductsByNameAsync("Apple");
        foreach (var product in searchResults)
        {
            Console.WriteLine($"- {product.Name} - {product.Price}");
        }
    }
}