namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class UserRoleEntityTypeConfiguration : EntityTypeConfigurationBase<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", InfrastructureDefaults.IdentityDbSchema);
            builder.Property("_roleId").HasColumnName("RoleId");

            builder.HasIndex("UserId","_roleId").IsUnique();
        }
    }
}
