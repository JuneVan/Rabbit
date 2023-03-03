namespace Rabbit.Domain.Auditing
{
    public interface IAudited : ICreationAudited, IModificationAudited
    {
    }
}