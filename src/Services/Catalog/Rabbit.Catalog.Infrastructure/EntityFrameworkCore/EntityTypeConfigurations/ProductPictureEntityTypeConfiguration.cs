namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class ProductPictureEntityTypeConfiguration : EntityTypeConfigurationBase<ProductPicture>
    {
        public override void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            base.Configure(builder);
            builder.ToTable("ProductPictures");

            builder.Property(x => x.Url).HasMaxLength(128).IsRequired();
        }
    }
}
