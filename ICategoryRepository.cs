namespace Product.Core
{ 
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetTopUsedCategories(int count);
    }
}