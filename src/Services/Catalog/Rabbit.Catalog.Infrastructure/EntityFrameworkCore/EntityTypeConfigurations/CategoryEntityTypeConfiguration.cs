namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class CategoryEntityTypeConfiguration : EntityTypeConfigurationBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories");

            builder.Property("_name").HasColumnName("Name");
            builder.Property("_parentId").HasColumnName("ParentId");
            builder.Property("_displayOrder").HasColumnName("DisplayOrder");
        }
    }
}
