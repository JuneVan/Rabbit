namespace Rabbit.Domain.Auditing
{
    public interface IHasModificationTime
    {
        DateTime? LastModifiedTime { get; set; }
    }
}