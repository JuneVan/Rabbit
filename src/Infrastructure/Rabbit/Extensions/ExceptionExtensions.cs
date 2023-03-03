namespace Rabbit.Extensions
{
    /// <summary>
    /// Exception��չ��
    /// </summary>
    public static class ExceptionExtensions
    {
        public static void ReThrow(this Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }
}