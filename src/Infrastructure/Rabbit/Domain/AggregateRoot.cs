namespace Rabbit.Domain
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents ?? new List<IDomainEvent>();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (_domainEvents == null) _domainEvents = new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
