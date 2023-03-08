namespace Rabbit.Events
{
    public abstract class EntityEventHelperBase : IEntityEventHelper
    {
        public async Task SendEntityChangeEventAsync(object entity)
        {
            await PublishEvent(typeof(EntityChangedEvent<>), entity);
        }
        public async Task SendEntityCreatedEventAsync(object entity)
        {
            await PublishEvent(typeof(EntityCreatedEvent<>), entity);
        }
        public async Task SendEntityUpdatedEventAsync(object entity)
        {
            await PublishEvent(typeof(EntityUpdatedEvent<>), entity);
        }
        public async Task SendEntityDeletedEventAsync(object entity)
        {
            await PublishEvent(typeof(EntityDeletedEvent<>), entity);
        }
        protected abstract Task PublishEvent(Type genericEventType, object entity);
    }
}
