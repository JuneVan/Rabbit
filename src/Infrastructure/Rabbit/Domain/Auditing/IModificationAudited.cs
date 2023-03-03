namespace Rabbit.Domain.Auditing
{
    public interface IModificationAudited : IHasModificationTime
    {
        int? LastModifierUserId { get; set; }
    }
}