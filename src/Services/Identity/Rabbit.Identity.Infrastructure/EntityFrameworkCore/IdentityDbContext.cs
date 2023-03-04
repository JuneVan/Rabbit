namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore
{
    public class IdentityDbContext : EfCoreDbContext<IdentityDbContext>
    {
        public IdentityDbContext(DbContextOptions options, IServiceProvider serviceProvider)
           : base(options, serviceProvider)
        {

        }
        protected override string Schema => InfrastructureDefaults.IdentityDbSchema;
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
