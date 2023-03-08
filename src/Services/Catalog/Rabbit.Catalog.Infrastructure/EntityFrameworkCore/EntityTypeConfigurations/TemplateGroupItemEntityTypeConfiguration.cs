namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class TemplateGroupItemEntityTypeConfiguration : EntityTypeConfigurationBase<TemplateGroupItem>
    {
        public override void Configure(EntityTypeBuilder<TemplateGroupItem> builder)
        {
            base.Configure(builder);
            builder.ToTable("TemplateGroupItems");
        }
    }
}
