namespace Rabbit.Data.EntityFrameworkCore
{
    public class EFCoreUnitOfWork<TDbContext> : IUnitOfWork
          where TDbContext : EFCoreDbContext<TDbContext>
    {
        private readonly IDbContextTransaction _contextTransaction;
        private readonly TDbContext _context;
        private readonly IThreadSignal _signal;
        public EFCoreUnitOfWork(TDbContext context,
            IThreadSignal signal)
        {
            _context = context;
            _signal = signal;
            _contextTransaction = _context.Database.BeginTransaction();
        }
        protected CancellationToken CancellationToken => _signal.CancellationToken;
        public void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
          where TAggregateRoot : class, IAggregateRoot
        {
            _context.Set<TAggregateRoot>().Add(entity);
        }
        public void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
        public async Task<int> CommitAsync()
        {
            int result;
            try
            {
                result = await _context.SaveChangesAsync(CancellationToken);
                await _contextTransaction.CommitAsync(CancellationToken);
            }
            catch
            {
                await _contextTransaction.RollbackAsync(CancellationToken);
                throw;
            }
            return result;
        }

        public void Dispose()
        {
            if (_contextTransaction != null)
                _contextTransaction.Dispose();
            if (_context != null)
                _context.Dispose();
        }
    }
}
