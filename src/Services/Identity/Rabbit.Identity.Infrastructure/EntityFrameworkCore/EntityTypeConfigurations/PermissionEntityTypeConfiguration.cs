namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class PermissionEntityTypeConfiguration : EntityTypeConfigurationBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions", InfrastructureDefaults.IdentityDbSchema);

            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(128);
            builder.Ignore(x => x.DomainEvents);

            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
