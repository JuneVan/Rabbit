namespace Rabbit.Events
{
    public interface IEntityChangeEventHelper
    {
        Task PublishEntityChangeEvent(object entity);
        Task PublishEntityCreatedEvent(object entity);
        Task PublishUpdatedEvent(object entity);
        Task PublishEntityDeletedEvent(object entity);
    }
}
