using AdvWorksAPI.DataAccessEF6.Data;
using AdvWorksAPI.DataAccessEF6;
using AdvWorksAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdvWorksAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorksContext _context;
        public ProductRepository(AdventureWorksContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductID == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(x => x.ProductID == productId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }


    }
}
