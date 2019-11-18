using Microsoft.EntityFrameworkCore;
using Product.Core.Repositories;
using Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Repositories
{
    public class ProductRepository : Repository<ProductInfo>, IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductInfo>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductInfo>> GetProducts(int CategoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == CategoryId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductInfo>> GetProductsWithCategeory()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
