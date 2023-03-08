namespace Rabbit.Events
{
    public class MediatREntityEventHelper : EntityEventHelperBase
    {
        private readonly AsyncContinueMediator _mediator;
        private readonly IThreadSignal _signal;
        private readonly ILogger _logger;
        public MediatREntityEventHelper(AsyncContinueMediator mediator,
            IThreadSignal signal,
            ILogger<MediatREntityEventHelper> logger)
        {
            _mediator = mediator;
            _signal = signal;
            _logger = logger;
        }
        protected override async Task PublishEvent(Type genericEventType, object entity)
        {
            _logger.LogDebug(message: $"发布实体事件`{entity.GetType()}`-`{genericEventType.Name}`。");
            Type entityType = entity.GetType();
            Type eventType = genericEventType.MakeGenericType(entityType);
            var @event = Activator.CreateInstance(eventType, new[] { entity });
            if (@event != null)
                await _mediator.Publish(@event, _signal.CancellationToken);
        } 
    }
}
