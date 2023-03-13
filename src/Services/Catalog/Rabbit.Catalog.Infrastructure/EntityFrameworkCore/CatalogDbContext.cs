using Rabbit.Data.EntityFrameworkCore;
using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore
{
    public class CatalogDbContext : EFCoreDbContext<CatalogDbContext>
    {
        public CatalogDbContext(DbContextOptions options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {

        }
        protected override string Schema => InfrastructureDefaults.CatalogDbSchema;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeOption> AttributeOptions { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<AttributeGroupItem> AttributeGroupItems { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
