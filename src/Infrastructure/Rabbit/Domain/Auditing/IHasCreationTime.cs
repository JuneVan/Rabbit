namespace Rabbit.Domain.Auditing
{
    public interface IHasCreationTime
    {
        DateTime CreatedTime { get; set; }
    }
}