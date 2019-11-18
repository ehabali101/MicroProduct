using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Product.Domain;

namespace Product.Core.Repositories
{
    public interface IProductRepository : IRepository<ProductInfo>
    {
        Task<IEnumerable<ProductInfo>> GetProducts();
        Task<IEnumerable<ProductInfo>> GetProducts(int CategoryId);
        Task<IEnumerable<ProductInfo>> GetProductsWithCategeory();
    }
}
