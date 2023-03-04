using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Rabbit.Events;

namespace Rabbit.Catalog.Infrastructure.Caching.Synchronizers
{
    internal class CatagoryCacheSynchronizer : IConsumer<EntityChangedEvent<Category>>
    {
        private readonly IDistributedCache _distributedCache;
        public CatagoryCacheSynchronizer(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task Consume(ConsumeContext<EntityChangedEvent<Category>> context)
        {
            await _distributedCache.RemoveAsync("aa");
        }
    }
}
