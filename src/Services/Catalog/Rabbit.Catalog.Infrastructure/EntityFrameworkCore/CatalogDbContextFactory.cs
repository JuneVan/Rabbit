namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore
{
    public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            ServiceCollection service = new ServiceCollection();
            DbContextOptionsBuilder<CatalogDbContext> optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=AntDb;UserName=postgre;Password=123456;");
            return new CatalogDbContext(optionsBuilder.Options, service.BuildServiceProvider());
        }
    }
}
