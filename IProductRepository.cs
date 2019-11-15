namespace Product.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProducts(int CategoryId);
        IEnumerable<Product> GetProductsWithCategeory();

    }
}