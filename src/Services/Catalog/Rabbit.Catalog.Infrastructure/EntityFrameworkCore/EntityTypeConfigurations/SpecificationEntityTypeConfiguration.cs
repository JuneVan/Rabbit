namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class SpecificationEntityTypeConfiguration : EntityTypeConfigurationBase<Specification>
    {
        public override void Configure(EntityTypeBuilder<Specification> builder)
        {
            base.Configure(builder);

            builder.ToTable("Specifications");

            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.Property(x => x.SKU).HasMaxLength(64);
            builder.Property(x => x.Cover).HasMaxLength(128);

            builder.HasMany(x => x.Attributes).WithOne().HasForeignKey(fk => fk.SpecificationId);
            builder.HasMany(x => x.Pictures).WithOne().HasForeignKey(fk => fk.SpecificationId);
        }
    }
}
