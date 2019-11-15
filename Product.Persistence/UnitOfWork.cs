using Product.Core;
using Product.Core.Repositories;
using Product.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        private readonly ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
