namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class RoleEntityTypeConfiguration : EntityTypeConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", InfrastructureDefaults.IdentityDbSchema);


            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(128);

            builder.Ignore(x => x.DomainEvents);

            builder.HasMany(x => x.Permissions).WithOne().HasForeignKey("RoleId");

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
