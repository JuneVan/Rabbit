namespace Rabbit.Events
{
    /// <summary>
    /// 事件接口
    /// </summary>
    public interface IEvent : INotification
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
