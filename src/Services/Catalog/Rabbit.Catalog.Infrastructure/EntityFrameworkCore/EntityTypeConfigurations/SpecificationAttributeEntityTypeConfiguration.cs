namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class SpecificationAttributeEntityTypeConfiguration : EntityTypeConfigurationBase<SpecificationAttribute>
    {
        public override void Configure(EntityTypeBuilder<SpecificationAttribute> builder)
        {
            base.Configure(builder);
            builder.ToTable("SpecificationAttributes");

            builder.Property(x => x.AttributeValue).HasMaxLength(128).IsRequired();
        }
    }
}
