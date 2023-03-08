namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class TemplateGroupEntityTypeConfiguration : EntityTypeConfigurationBase<TemplateGroup>
    {
        public override void Configure(EntityTypeBuilder<TemplateGroup> builder)
        {
            base.Configure(builder);
            builder.ToTable("TemplateGroups");
            builder.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.GroupId);

        }
    }
}
