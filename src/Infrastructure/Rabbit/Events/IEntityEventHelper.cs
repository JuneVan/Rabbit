namespace Rabbit.Events
{
    public interface IEntityEventHelper
    {
        Task SendEntityChangeEventAsync(object entity);
        Task SendEntityCreatedEventAsync(object entity);
        Task SendEntityUpdatedEventAsync(object entity);
        Task SendEntityDeletedEventAsync(object entity);
    }
}
