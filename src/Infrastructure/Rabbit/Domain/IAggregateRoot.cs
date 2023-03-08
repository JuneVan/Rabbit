namespace Rabbit.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        void AddDomainEvent(IDomainEvent domainEvent);
        void ClearDomainEvents();
    }
}
