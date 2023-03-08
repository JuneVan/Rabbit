namespace Rabbit.Events
{
    public interface IEntityEventHelper
    {
        Task PublishEntityChangeEvent(object entity);
        Task PublishEntityCreatedEvent(object entity);
        Task PublishUpdatedEvent(object entity);
        Task PublishEntityDeletedEvent(object entity);
    }
}
