using System.Collections.Generic;
using System.Threading.Tasks;
using HexaProductCatalog.Domain.Entities;

namespace HexaProductCatalog.Domain.Interfaces
{
    public interface IProductProxy
    {
        Task<IEnumerable<Product>> GetExternalProducts();
    }
}