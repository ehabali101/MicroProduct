using Product.Core;
using Product.Core.Repositories;
using Product.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        bool disposed = false;
        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        private readonly ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
