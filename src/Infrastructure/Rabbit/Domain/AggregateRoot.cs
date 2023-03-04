namespace Rabbit.Domain
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        private List<DomainEvent> _domainEvents;
        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents ?? new List<DomainEvent>();

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            if (_domainEvents == null) _domainEvents = new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
