namespace Rabbit.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyList<IEvent> DomainEvents { get; }
        void AddDomainEvent(IEvent domainEvent);
        void ClearDomainEvents();
    }
}
