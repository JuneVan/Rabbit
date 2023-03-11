namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class AttributeGroupItemEntityTypeConfiguration : EntityTypeConfigurationBase<AttributeGroupItem>
    {
        public override void Configure(EntityTypeBuilder<AttributeGroupItem> builder)
        {
            base.Configure(builder);
            builder.ToTable("AttributeGroupItems"); 

            builder.HasIndex(x => new { x.AttributeGroupId,   x.AttributeId }).IsUnique();
        }
    }
}
