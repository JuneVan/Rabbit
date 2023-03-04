namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            ServiceCollection service = new ServiceCollection();
            DbContextOptionsBuilder<IdentityDbContext> optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=RabbitDb;UserName=postgres;Password=123456;");
            return new IdentityDbContext(optionsBuilder.Options, service.BuildServiceProvider());
        }
    }
}
