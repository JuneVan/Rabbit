namespace Rabbit.AspNetCore.Threading
{
    public class HttpThreadSignal : IThreadSignal
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HttpThreadSignal(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual CancellationToken CancellationToken => _httpContextAccessor?.HttpContext?.RequestAborted ?? CancellationToken.None;
    }
}
