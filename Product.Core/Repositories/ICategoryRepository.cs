using Product.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetTopUsedCategories(int count);
    }
}
