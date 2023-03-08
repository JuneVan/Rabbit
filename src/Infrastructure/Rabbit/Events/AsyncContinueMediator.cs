namespace Rabbit.Events
{
    public class AsyncContinueMediator : Mediator
    {
        public AsyncContinueMediator(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override async Task PublishCore(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification, CancellationToken cancellationToken)
        {
            List<Task> tasks = new List<Task>();
            List<Exception> exceptions = new List<Exception>();

            foreach (var handlerExecutor in handlerExecutors)
            {
                try
                {
                    tasks.Add(handlerExecutor.HandlerCallback(notification, cancellationToken));
                }
                catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
                {
                    exceptions.Add(ex);
                }
            }

            try
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                exceptions.AddRange(ex.Flatten().InnerExceptions);
            }
            catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
            {
                exceptions.Add(ex);
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }

}