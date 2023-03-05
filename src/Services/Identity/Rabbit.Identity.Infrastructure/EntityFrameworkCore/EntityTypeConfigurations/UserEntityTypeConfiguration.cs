namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : EntityTypeConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", InfrastructureDefaults.IdentityDbSchema);

            builder.Property(x => x.Username).HasMaxLength(128);
            builder.Property(x => x.PasswordHash).HasMaxLength(64);
            builder.Property(x => x.Email).HasMaxLength(128);
            builder.Property(x => x.Phone).HasMaxLength(32);
            builder.Ignore(x => x.DomainEvents);
            builder.HasMany(x => x.Roles).WithOne().HasForeignKey(x => x.UserId);

            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
        }
    }
}
