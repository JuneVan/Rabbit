namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class ProductAttributeEntityTypeConfiguration : EntityTypeConfigurationBase<ProductAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            base.Configure(builder);
            builder.ToTable("ProductAttributes");

            builder.Property(x => x.AttributeValue).HasMaxLength(128).IsRequired();
        }
    }
}
