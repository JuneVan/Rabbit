namespace Rabbit.Events
{
    public record EntityDeletedEvent<TEntity> : EntityChangedEvent<TEntity>
    {
        public EntityDeletedEvent(TEntity entity)
            : base(entity)
        {

        }
    }
}
