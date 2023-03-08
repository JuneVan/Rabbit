namespace Rabbit.Domain
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        private List<IEvent> _domainEvents;
        public IReadOnlyList<IEvent> DomainEvents => _domainEvents ?? new List<IEvent>();

        public void AddDomainEvent(IEvent domainEvent)
        {
            if (_domainEvents == null) _domainEvents = new List<IEvent>();
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
