namespace Rabbit.AspNetCore.Http
{
    /// <summary>
    /// IHeaderDictionary扩展类
    /// </summary>
    public static class HeadersExtensions
    {
        /// <summary>
        /// 获取请求头中的Bearer值
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string GetBearerToken(this IHeaderDictionary headers)
        {
            string authorization = headers.Authorization;
            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var tokenValue = authorization["Bearer ".Length..].Trim();
                return tokenValue;
            }
            return null;
        }
    }
}
