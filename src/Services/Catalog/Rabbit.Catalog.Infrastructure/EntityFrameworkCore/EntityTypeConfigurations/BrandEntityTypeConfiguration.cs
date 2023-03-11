namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class BrandEntityTypeConfiguration: EntityTypeConfigurationBase<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);
            builder.ToTable("Brands");
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Logo).HasMaxLength(512).IsRequired();
        }
    }
}
