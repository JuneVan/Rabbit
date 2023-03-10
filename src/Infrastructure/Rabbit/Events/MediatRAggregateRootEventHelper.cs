namespace Rabbit.Events
{
    public class MediatRAggregateRootEventHelper : AggregateRootChangedEventHandlerBase
    {
        private readonly AsyncContinueMediator _mediator;
        private readonly IThreadSignal _signal;
        private readonly ILogger _logger;
        public MediatRAggregateRootEventHelper(AsyncContinueMediator mediator,
            IThreadSignal signal,
            ILogger<MediatRAggregateRootEventHelper> logger)
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
