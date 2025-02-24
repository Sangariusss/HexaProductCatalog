using HexaProductCatalog.Domain.Entities;

namespace HexaProductCatalog.Application.Services;

public interface IProductService
{
    Task AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task DeleteProductAsync(int id);
    Task<IEnumerable<Product>> SearchProductsByNameAsync(string name);
}

