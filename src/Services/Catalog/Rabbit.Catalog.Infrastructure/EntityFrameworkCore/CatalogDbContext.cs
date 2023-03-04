namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore
{
    public class CatalogDbContext : EfCoreDbContext<CatalogDbContext>
    {
        public CatalogDbContext(DbContextOptions options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {

        }
        protected override string Schema =>InfrastructureDefaults.CatalogDbSchema;
        public DbSet<Category> Categories { get; set; }
    }
}
