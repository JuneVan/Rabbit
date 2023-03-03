namespace Rabbit.Events
{
    public record EntityUpdatedEvent<TEntity> : EntityChangedEvent<TEntity>
    {
        public EntityUpdatedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
