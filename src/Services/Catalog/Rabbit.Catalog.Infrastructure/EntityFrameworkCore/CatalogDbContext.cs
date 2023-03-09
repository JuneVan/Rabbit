using Rabbit.Catalog.AggregateModels.AttributeAggregate;
using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore
{
    public class CatalogDbContext : EfCoreDbContext<CatalogDbContext>
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
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateGroup> TemplateGroups { get; set; }
        public DbSet<TemplateGroupItem> TemplateGroupItems { get; set; }
    }
}
