namespace Rabbit.Events
{
    public record AggregateRootDeletedEvent<TEntity> : AggregateRootChangedEvent<TEntity>
    {
        public AggregateRootDeletedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
