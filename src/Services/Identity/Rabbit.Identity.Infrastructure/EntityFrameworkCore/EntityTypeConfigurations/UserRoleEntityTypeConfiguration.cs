namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class UserRoleEntityTypeConfiguration : EntityTypeConfigurationBase<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", InfrastructureDefaults.IdentityDbSchema);

            builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
        }
    }
}
