namespace Rabbit.Catalog.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class UnitEntityTypeConfiguration : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            base.Configure(builder);
            builder.ToTable("Units");

            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        }
    }
}
