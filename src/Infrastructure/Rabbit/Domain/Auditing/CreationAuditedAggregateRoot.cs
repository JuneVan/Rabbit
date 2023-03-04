namespace Rabbit.Domain.Auditing
{
    public abstract class CreationAuditedAggregateRoot : AggregateRoot, ICreationAudited
    {
        protected CreationAuditedAggregateRoot()
        {
            CreatedTime = DateTime.Now;
        }
        public virtual DateTime CreatedTime { get; set; }

        public virtual int CreatorUserId { get; set; }

    }
}
