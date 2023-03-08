namespace Rabbit.Events
{
    public class MediatREventBus : IEventBus
    {
        private readonly AsyncContinueMediator _mediator;
        private readonly IThreadSignal _signal;
        private readonly ILogger _logger;
        public MediatREventBus(AsyncContinueMediator mediator,
            IThreadSignal signal,
            ILogger<MediatREventBus> logger)
        {
            _mediator = mediator;
            _signal = signal;
            _logger = logger;
        }
        public async Task SendAsync<TEvent>(TEvent @event) where TEvent : IEvent, new()
        {
            _logger.LogDebug(message: $"发布事件`{@event.GetType()}`-`{@event.GetType().Name}`。");

            await _mediator.Publish(@event, _signal.CancellationToken);
        }

    }
}
