using AdvWorksAPI.DataAccessEF6;
using System.Collections.Generic;

namespace AdvWorksAPI.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProduct(int productId);
        IEnumerable<Product> GetProducts();
        bool ProductExists(int productId);
        bool Save();
    }
}
