namespace Rabbit.Events
{
    public record EntityCreatedEvent<TEntity> : EntityChangedEvent<TEntity>
    {
        public EntityCreatedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
