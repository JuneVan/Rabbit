namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    internal class PermissionEntityTypeConfiguration : EntityTypeConfigurationBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions", InfrastructureDefaults.IdentityDbSchema);

            builder.Property("_name").HasColumnName("Name").HasMaxLength(128);
            builder.Property("_description").HasColumnName("Description").HasMaxLength(128);
            builder.Property("_parentId").HasColumnName("ParentId");
            builder.Ignore(x => x.DomainEvents);

            builder.HasIndex("_name").IsUnique();

        }
    }
}
