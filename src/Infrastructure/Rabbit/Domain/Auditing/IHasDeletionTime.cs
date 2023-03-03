namespace Rabbit.Domain.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletedTime { get; set; }
    }
}