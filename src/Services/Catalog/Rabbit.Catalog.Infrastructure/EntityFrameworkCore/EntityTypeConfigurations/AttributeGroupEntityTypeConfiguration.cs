namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class AttributeGroupEntityTypeConfiguration : EntityTypeConfigurationBase<AttributeGroup>
    {
        public override void Configure(EntityTypeBuilder<AttributeGroup> builder)
        {
            base.Configure(builder);
            builder.ToTable("AttributeGroups");
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.AttributeGroupId); 

        }
    }
}
