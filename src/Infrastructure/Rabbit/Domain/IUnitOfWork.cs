namespace Rabbit.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
                    where TAggregateRoot : class, IAggregateRoot;
        void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
           where TAggregateRoot : class, IAggregateRoot;
        void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity)
           where TAggregateRoot : class, IAggregateRoot;
        Task<int> CommitAsync();
    }
}
