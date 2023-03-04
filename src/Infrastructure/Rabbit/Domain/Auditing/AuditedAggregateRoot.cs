namespace Rabbit.Domain.Auditing
{
    public class AuditedAggregateRoot : CreationAuditedAggregateRoot, IAudited, IAggregateRoot
    {
        public virtual DateTime? LastModifiedTime { get; set; }
        public virtual int? LastModifierUserId { get; set; }
    }
}
