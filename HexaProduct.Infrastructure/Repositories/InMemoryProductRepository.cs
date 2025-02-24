using HexaProductCatalog.Domain.Entities;
using HexaProductCatalog.Domain.Interfaces;

namespace HexaProductCatalog.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public void Add(Product product)
    {
        product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
        _products.Add(product);
    }

    public void Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public IEnumerable<Product> SearchByName(string name)
    {
        return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}
