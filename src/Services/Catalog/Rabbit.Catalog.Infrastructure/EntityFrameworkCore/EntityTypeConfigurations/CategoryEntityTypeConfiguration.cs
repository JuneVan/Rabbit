namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class CategoryEntityTypeConfiguration : EntityTypeConfigurationBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories");

            builder.HasMany(x => x.Children).WithOne().HasForeignKey(x => x.ParentId);
        }
    }
}
