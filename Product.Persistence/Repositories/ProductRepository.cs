using Product.Core.Repositories;
using Product.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Product.Persistence.Repositories
{
    public class ProductRepository : Repository<ProductInfo>, IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductInfo> GetProducts(int CategoryId)
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == CategoryId).ToList();
        }

        public IEnumerable<ProductInfo> GetProductsWithCategeory()
        {
            return _context.Products
                .Include(p => p.Category)
                .ToList();
        }
    }
}
