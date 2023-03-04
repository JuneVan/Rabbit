namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class RolePermissionEntityTypeConfiguration : EntityTypeConfigurationBase<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions", InfrastructureDefaults.IdentityDbSchema);

            builder.Property("_permissionId").HasColumnName("PermissionId");
            builder.HasIndex("_permissionId", "RoleId").IsUnique();
        }
    }
}
