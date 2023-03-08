namespace Rabbit.Events
{
    public abstract class EntityEventHelperBase : IEntityEventHelper
    {
        public async Task PublishEntityChangeEvent(object entity)
        {
            await PublishEvent(typeof(EntityChangedEvent<>), entity);
        }
        public async Task PublishEntityCreatedEvent(object entity)
        {
            await PublishEvent(typeof(EntityCreatedEvent<>), entity);
        }
        public async Task PublishUpdatedEvent(object entity)
        {
            await PublishEvent(typeof(EntityUpdatedEvent<>), entity);
        }
        public async Task PublishEntityDeletedEvent(object entity)
        {
            await PublishEvent(typeof(EntityDeletedEvent<>), entity);
        }
        protected abstract Task PublishEvent(Type genericEventType, object entity);
    }
}
