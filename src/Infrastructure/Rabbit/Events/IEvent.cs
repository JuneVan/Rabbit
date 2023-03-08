namespace Rabbit.Events
{
    public class IEvent : INotification
    {
        public DateTime CreatedTime { get; set; }
    }
}
