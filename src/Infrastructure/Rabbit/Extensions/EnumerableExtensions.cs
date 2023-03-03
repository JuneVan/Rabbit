namespace Rabbit.Extensions
{
    /// <summary>
    /// IEnumerable扩展类
    /// </summary>
    public static class EnumerableExtensions
    {
        public static string JoinAsString(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }
        public static string JoinAsString<T>(this IEnumerable<T> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}
