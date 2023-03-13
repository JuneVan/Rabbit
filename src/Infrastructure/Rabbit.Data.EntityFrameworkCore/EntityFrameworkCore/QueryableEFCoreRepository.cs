namespace Rabbit.Data.EntityFrameworkCore
{
    public class QueryableEFCoreRepository<TDbContext, TEntity> : IQueryableRepository<TEntity>
        where TEntity : class, IEntity
        where TDbContext : DbContext
    {
        private readonly IThreadSignal _signal;
        public QueryableEFCoreRepository(IUnitOfWork unitOfWork,
            TDbContext context,
            IThreadSignal signal)
        {
            Context = context;
            UnitOfWork = unitOfWork;
            _signal = signal;
        }
        protected TDbContext Context { get; }
        public IUnitOfWork UnitOfWork { get; }
        protected CancellationToken CancellationToken => _signal.CancellationToken;
        public virtual async Task<TEntity> FirstOrDefaultAsync(int id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, CancellationToken);
        }
        public virtual async Task<TEntity> IncludingFirstOrDefaultAsync(int id, params Expression<Func<TEntity, object>>[] propertySelectors)
        {

            IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();

            if (propertySelectors != null)
            {
                foreach (Expression<Func<TEntity, object>> propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id, CancellationToken);
        }
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {

            return await Context.Set<TEntity>().FirstOrDefaultAsync(expression, CancellationToken);
        }
        public async Task<TEntity> IncludingFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] propertySelectors)
        {

            IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();

            if (propertySelectors != null)
            {
                foreach (Expression<Func<TEntity, object>> propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }
            return await query.FirstOrDefaultAsync(expression, CancellationToken);
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {

            return await Context.Set<TEntity>().CountAsync(expression, CancellationToken);
        }
        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();

            if (propertySelectors != null)
            {
                foreach (Expression<Func<TEntity, object>> propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }
            return query;
        }
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll()
                .ToListAsync(CancellationToken);
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await GetAll()
                .Where(expression)
                .ToListAsync(CancellationToken);
        }
    }
}
