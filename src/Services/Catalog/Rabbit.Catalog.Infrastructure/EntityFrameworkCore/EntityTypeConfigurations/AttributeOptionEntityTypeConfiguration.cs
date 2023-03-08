using Rabbit.Catalog.AggregateModels.AttributeAggregate;

namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class AttributeOptionEntityTypeConfiguration: EntityTypeConfigurationBase<AttributeOption>
    {
        public override void Configure(EntityTypeBuilder<AttributeOption> builder)
        {
            base.Configure(builder);
            builder.ToTable("AttributeOptions");
        }
    }
}
