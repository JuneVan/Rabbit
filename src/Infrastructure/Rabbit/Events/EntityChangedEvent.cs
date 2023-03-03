namespace Rabbit.Events
{
    public record EntityChangedEvent<TEntity>
    {
        public EntityChangedEvent(TEntity entity)
        {
            Entity = entity;

        }
        public TEntity Entity { get; private set; }

    }
}
