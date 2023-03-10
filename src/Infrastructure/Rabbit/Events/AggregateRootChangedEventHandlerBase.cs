namespace Rabbit.Events
{
    public abstract class AggregateRootChangedEventHandlerBase : IAggregateRootChangedEventHandler
    {
        public async Task SendChangeEventAsync(object entity)
        {
            await PublishEvent(typeof(AggregateRootChangedEvent<>), entity);
        }
        public async Task SendCreatedEventAsync(object entity)
        {
            await PublishEvent(typeof(AggregateRootCreatedEvent<>), entity);
        }
        public async Task SendUpdatedEventAsync(object entity)
        {
            await PublishEvent(typeof(AggregateRootUpdatedEvent<>), entity);
        }
        public async Task SendDeletedEventAsync(object entity)
        {
            await PublishEvent(typeof(AggregateRootDeletedEvent<>), entity);
        }
        protected abstract Task PublishEvent(Type genericEventType, object entity);
    }
}
