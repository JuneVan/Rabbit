namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class SpecificationPictureEntityTypeConfiguration : EntityTypeConfigurationBase<SpecificationPicture>
    {
        public override void Configure(EntityTypeBuilder<SpecificationPicture> builder)
        {
            base.Configure(builder);
            builder.ToTable("SpecificationPictures");

            builder.Property(x => x.Url).HasMaxLength(128).IsRequired();
        }
    }
}
