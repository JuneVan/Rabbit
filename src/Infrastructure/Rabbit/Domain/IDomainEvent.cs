namespace Rabbit.Domain
{
    /// <summary>
    /// 领域事件接口
    /// </summary>
    public interface IDomainEvent : IEvent
    {
        /// <summary>
        /// 聚合根Id
        /// </summary>
        public int AggregateRootId { get; set; }
    }
}
