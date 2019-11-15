using Product.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        int Complete();
    }
}
