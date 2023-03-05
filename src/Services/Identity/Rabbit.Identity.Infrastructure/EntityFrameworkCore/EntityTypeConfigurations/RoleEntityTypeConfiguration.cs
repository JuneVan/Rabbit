namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class RoleEntityTypeConfiguration : EntityTypeConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", InfrastructureDefaults.IdentityDbSchema);


            builder.Property("_name").HasColumnName("Name").HasMaxLength(128);
            builder.Property("_description").HasColumnName("Description").HasMaxLength(128);
            builder.Property("_isActive").HasColumnName("IsActive");
            builder.Property("_isSystemRole").HasColumnName("IsSystemRole");

            builder.Ignore(x => x.DomainEvents);

            builder.HasMany(x => x.Permissions).WithOne().HasForeignKey("RoleId");

            builder.HasIndex("_name").IsUnique();
        }
    }
}
