namespace Rabbit.Domain.Auditing
{
    public abstract class FullAuditedAggregateRoot : AuditedAggregateRoot, IFullAudited
    {
        public virtual bool IsDeleted { get; set; }

        public virtual int? DeleterUserId { get; set; }

        public virtual DateTime? DeletedTime { get; set; }
    }
}