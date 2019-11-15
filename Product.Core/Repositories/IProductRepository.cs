using System;
using System.Collections.Generic;
using System.Text;
using Product.Domain;

namespace Product.Core.Repositories
{
    public interface IProductRepository : IRepository<ProductInfo>
    {
        IEnumerable<ProductInfo> GetProducts(int CategoryId);
        IEnumerable<ProductInfo> GetProductsWithCategeory();
    }
}
