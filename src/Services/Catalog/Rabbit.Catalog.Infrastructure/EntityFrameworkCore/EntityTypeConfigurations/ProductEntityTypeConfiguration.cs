namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class ProductEntityTypeConfiguration : EntityTypeConfigurationBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable("Products");

            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.Property(x => x.MetaTitle).HasMaxLength(128);
            builder.Property(x => x.MetaDescription).HasMaxLength(128);
            builder.Property(x => x.MetaKeywords).HasMaxLength(64);

            builder.HasMany(x => x.Attributes).WithOne().HasForeignKey(fk => fk.ProductId);
            builder.HasMany(x => x.Pictures).WithOne().HasForeignKey(fk => fk.ProductId);
        }
    }
}
