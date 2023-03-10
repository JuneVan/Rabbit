namespace Rabbit.Events
{
    public interface IAggregateRootChangedEventHandler
    {
        Task SendChangeEventAsync(object entity);
        Task SendCreatedEventAsync(object entity);
        Task SendUpdatedEventAsync(object entity);
        Task SendDeletedEventAsync(object entity);
    }
}
