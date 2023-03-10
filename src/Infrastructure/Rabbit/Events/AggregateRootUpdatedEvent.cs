namespace Rabbit.Events
{
    public record AggregateRootUpdatedEvent<TEntity> : AggregateRootChangedEvent<TEntity>
    {
        public AggregateRootUpdatedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
