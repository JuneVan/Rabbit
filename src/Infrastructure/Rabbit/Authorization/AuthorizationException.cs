namespace Rabbit.Authorization
{
    public class AuthorizationException : RabbitException, IHasLogLevel
    {
        public AuthorizationException(string message) : base(message)
        {

        }
        public AuthorizationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public LogLevel Level => LogLevel.Warning;
    }
}
