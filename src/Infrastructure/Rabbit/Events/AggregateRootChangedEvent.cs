namespace Rabbit.Events
{
    public record AggregateRootChangedEvent<TEntity> : INotification
    {
        public AggregateRootChangedEvent(TEntity entity)
        {
            Entity = entity;

        }
        public TEntity Entity { get; private set; }

    }
}
