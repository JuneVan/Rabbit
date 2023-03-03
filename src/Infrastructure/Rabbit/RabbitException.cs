namespace Rabbit
{
    public class RabbitException : Exception
    {
        public RabbitException(string message) : base(message)
        {

        }
        public RabbitException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
