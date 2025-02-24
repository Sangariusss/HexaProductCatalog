using HexaProductCatalog.Domain.Entities;

namespace HexaProductCatalog.Domain.Interfaces;

public interface IProductRepository
{
    void Add(Product product);
    void Delete(int id);
    Product? GetById(int id);
    IEnumerable<Product> GetAll();
    IEnumerable<Product> SearchByName(string name);
}
