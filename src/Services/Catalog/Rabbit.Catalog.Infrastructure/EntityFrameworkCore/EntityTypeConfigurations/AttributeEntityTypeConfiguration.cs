using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class AttributeEntityTypeConfiguration : EntityTypeConfigurationBase<Attribute>
    {
        public override void Configure(EntityTypeBuilder<Attribute> builder)
        {
            base.Configure(builder);
            builder.ToTable("Attributes");
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.HasMany(x => x.Options).WithOne().HasForeignKey(x => x.AttributeId);
        }
    }
}
