using Microsoft.EntityFrameworkCore;
using Product.Domain;

namespace Product.Persistence
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductInfo> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(e => e.Category);
        }
    }
}
