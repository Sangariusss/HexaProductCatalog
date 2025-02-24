using HexaProductCatalog.Application.Services;
using HexaProductCatalog.Domain.Entities;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new List<Product>();

    public Task AddProductAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
    {
        var results = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<IEnumerable<Product>>(results);
    }

    public Task DeleteProductAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }
}