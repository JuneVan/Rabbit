namespace Rabbit.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyList<DomainEvent> DomainEvents { get; }
        void AddDomainEvent(DomainEvent domainEvent);
        void ClearDomainEvents();
    }
}
