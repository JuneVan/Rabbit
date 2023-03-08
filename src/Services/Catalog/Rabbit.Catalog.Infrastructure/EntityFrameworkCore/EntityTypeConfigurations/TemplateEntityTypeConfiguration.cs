namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class TemplateEntityTypeConfiguration:EntityTypeConfigurationBase<Template>
    {
        public override void Configure(EntityTypeBuilder<Template> builder)
        {
            base.Configure(builder);
            builder.ToTable("Templates");

            builder.HasMany(x=>x.Groups).WithOne().HasForeignKey(x=>x.TemplateId);
            builder.HasMany(x=>x.Items).WithOne().HasForeignKey(x=>x.TemplateId); 

        }
    }
}
