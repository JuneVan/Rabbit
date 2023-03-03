namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore
{
    public class CatalogDbContext : EfCoreDbContext<CatalogDbContext>
    {
        public CatalogDbContext(DbContextOptions options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
