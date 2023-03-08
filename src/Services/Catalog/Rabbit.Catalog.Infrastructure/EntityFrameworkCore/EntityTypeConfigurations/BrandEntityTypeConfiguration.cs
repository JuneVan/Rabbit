namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class BrandEntityTypeConfiguration: EntityTypeConfigurationBase<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);
            builder.ToTable("Brands");
        }
    }
}
