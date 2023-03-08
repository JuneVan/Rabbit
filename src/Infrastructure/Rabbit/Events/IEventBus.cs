namespace Rabbit.Events
{
    public interface IEventBus
    {
        /// <summary>
        /// 发布事件消息
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        /// <returns></returns>
        Task SendAsync<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
