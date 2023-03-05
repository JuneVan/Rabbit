namespace Rabbit.AspNetCore.Authorization
{
    public class UrlPermissionProvider : IPermissionProvider
    {
        private readonly IThreadSignal _signal;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UrlPermissionProvider(
             IThreadSignal signal,
             IHttpClientFactory httpClientFactory,
             IHttpContextAccessor httpContextAccessor,
             IOptions<PermissionOptions> options)
        {
            _signal = signal;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            RequestUrl = options?.Value?.RequestUrl;
        }
        protected string RequestUrl { get; private set; }
        public async Task<IList<string>> GetPermissionsAsync(int userId)
        {

            if (RequestUrl.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(RequestUrl), $"用户权限列表接口地址不能为空。");
            using var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{RequestUrl}?UserId={userId}")
            };
            string bearerToken = _httpContextAccessor.HttpContext.Request.Headers.GetBearerToken();
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var response = await client.SendWithRetryAsync(requestMessage, cancellationToken: _signal.CancellationToken, 3);
            using StreamReader reader = new(response.Content.ReadAsStream(), Encoding.UTF8);
            var result = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<string>>(result);
        }
    }
}
