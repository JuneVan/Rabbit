using MediatR;

namespace Rabbit.Catalog.Infrastructure.Caching.Synchronizers
{
    internal class CatagoryCacheSynchronizer : INotificationHandler<AggregateRootChangedEvent<Category>>
    {
        private readonly IDistributedCache _distributedCache;
        public CatagoryCacheSynchronizer(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(AggregateRootChangedEvent<Category> notification, CancellationToken cancellationToken)
        {
            await _distributedCache.RemoveAsync("aa");
        }
    }
}
