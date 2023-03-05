namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class RolePermissionEntityTypeConfiguration : EntityTypeConfigurationBase<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions", InfrastructureDefaults.IdentityDbSchema);

            builder.HasIndex(x => new { x.RoleId, x.PermissionId }).IsUnique();
        }
    }
}
