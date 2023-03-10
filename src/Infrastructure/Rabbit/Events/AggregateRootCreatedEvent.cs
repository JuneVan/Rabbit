namespace Rabbit.Events
{
    public record AggregateRootCreatedEvent<TEntity> : AggregateRootChangedEvent<TEntity>
    {
        public AggregateRootCreatedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
