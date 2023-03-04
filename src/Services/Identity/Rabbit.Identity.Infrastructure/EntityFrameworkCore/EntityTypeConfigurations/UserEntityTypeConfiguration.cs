namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : EntityTypeConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", InfrastructureDefaults.IdentityDbSchema);

            builder.Property("_username").HasColumnName("Username").HasMaxLength(128);
            builder.Property("_passwordHash").HasColumnName("PasswordHash").HasMaxLength(64);
            builder.Property("_email").HasColumnName("Email").HasMaxLength(128);
            builder.Property("_phone").HasColumnName("Phone").HasMaxLength(32);
            builder.Ignore(x => x.DomainEvents);
            builder.HasMany(x => x.Roles).WithOne().HasForeignKey("UserId");

            builder.HasIndex("_username").IsUnique();
        }
    }
}
