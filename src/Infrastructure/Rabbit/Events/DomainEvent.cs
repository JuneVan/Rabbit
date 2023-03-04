namespace Rabbit.Events
{
    public abstract class DomainEvent
    {
        public DateTime CreatedTime { get; set; }
    }
}
