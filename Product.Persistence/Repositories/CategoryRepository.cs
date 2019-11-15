using Product.Core.Repositories;
using Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ProductContext _context;

        public CategoryRepository(ProductContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetTopUsedCategories(int count)
        {
            return _context.Categories.OrderByDescending(c => c.Name).Take(count).ToList();
        }
    }
}
