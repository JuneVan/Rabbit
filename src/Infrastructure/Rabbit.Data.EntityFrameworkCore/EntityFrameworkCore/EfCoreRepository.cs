namespace Rabbit.Data.EntityFrameworkCore
{
    public class EFCoreRepository<TDbContext, TAggregateRoot> : QueryableEFCoreRepository<TDbContext, TAggregateRoot>,
        IRepository<TAggregateRoot>
       where TAggregateRoot : class, IAggregateRoot
        where TDbContext : DbContext
    {
        public EFCoreRepository(IUnitOfWork unitOfWork,
            TDbContext context,
            IThreadSignal signal) : base(unitOfWork, context, signal)
        {
        }
        public async Task<TAggregateRoot> InsertAsync(TAggregateRoot entity)
        {
            UnitOfWork.RegisterNew(entity);
            await Task.CompletedTask;
            return entity;
        }
        public async Task<int> InsertAndGetIdAsync(TAggregateRoot entity)
        {
            await InsertAsync(entity);
            await Context.SaveChangesAsync(CancellationToken);
            return entity.Id;
        }
        public async Task<TAggregateRoot> InsertOrUpdateAsync(TAggregateRoot entity)
        {
            if (entity.Id == default)
            {
                return await InsertAsync(entity);
            }
            else
            {
                return await UpdateAsync(entity);
            }
        }
        public async Task<TAggregateRoot> UpdateAsync(TAggregateRoot entity)
        {
            UnitOfWork.RegisterModified(entity);
            await Task.CompletedTask;
            return entity;
        }
        public async Task DeleteAsync(TAggregateRoot entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var entry = Context.ChangeTracker.Entries()
               .FirstOrDefault(
                   entry =>
                       entry.Entity is TAggregateRoot &&
                       EqualityComparer<int>.Default.Equals(id, ((TAggregateRoot)entry.Entity).Id)
               );

            if (entry.Entity is not TAggregateRoot entity)
                return;
            await DeleteAsync(entity);
        }
    }
}