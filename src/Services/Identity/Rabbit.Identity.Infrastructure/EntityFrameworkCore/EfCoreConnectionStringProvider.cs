namespace Rabbit.Identity.Infrastructure.EntityFrameworkCore
{
    public class EfCoreConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IdentityDbContext _context;
        public EfCoreConnectionStringProvider(IdentityDbContext context)
        {
            _context = context;
        }
        public string GetConnectionString()
        {
            return _context.Database.GetConnectionString();
        }
    }
}
