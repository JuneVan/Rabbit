namespace Rabbit.Events
{
    public class EntityChangeEventHelper : IEntityChangeEventHelper
    {
        readonly IPublishEndpoint _publishEndpoint;
        private readonly IThreadSignal _signal;
        private readonly ILogger _logger;
        public EntityChangeEventHelper(IPublishEndpoint publishEndpoint, IThreadSignal signal, ILogger<EntityChangeEventHelper> logger)
        {
            _publishEndpoint = publishEndpoint;
            _signal = signal;
            _logger = logger;
        }
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
        protected virtual async Task PublishEvent(Type genericEventType, object entity)
        {
            _logger.LogDebug(message: $"发布实体事件`{entity.GetType()}`-`{genericEventType.Name}`。");
            Type entityType = entity.GetType();
            Type eventType = genericEventType.MakeGenericType(entityType);
            var @event = Activator.CreateInstance(eventType, new[] { entity });
            if (@event != null)
                await _publishEndpoint.Publish(@event, _signal.CancellationToken);
        }

    }
}
