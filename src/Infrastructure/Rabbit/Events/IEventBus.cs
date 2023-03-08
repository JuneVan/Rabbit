namespace Rabbit.Events
{
    public interface IEventBus
    {
        Task SendAsync<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : IEvent, new();
    }
}
