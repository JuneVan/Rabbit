namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class CategoryEntityTypeConfiguration : EntityTypeConfigurationBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories");

            builder.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
        }
    }
}
