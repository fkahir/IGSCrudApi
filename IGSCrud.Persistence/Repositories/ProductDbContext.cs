using IGSCrud.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IGSCrud.Persistence.Repositories
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
