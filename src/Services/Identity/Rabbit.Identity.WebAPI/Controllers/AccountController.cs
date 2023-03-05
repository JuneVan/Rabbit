using Rabbit.Identity.WebAPI.Application.Queries;

namespace Rabbit.Identity.WebAPI.Controllers
{
    [Route("v1/[controller]/[action]")]
    public class AccountController : IdentityControllerBase
    {
        private readonly IAccountQuerier _querier;
        public AccountController(IServiceProvider serviceProvider,
            IAccountQuerier querier)
            : base(serviceProvider)
        {
            _querier = querier;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="command">Token参数</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] LoginCommand command)
        {
            var token = await Mediator.Send(command);
            if (Identifier.UserId.HasValue)
            {
                // 发送重新授权事件
                await Task.CompletedTask;
            }
            return token;
        }

        /// <summary>
        /// 获取当前授权用户的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ProfileModel> GetProfile()
        {
            return await _querier.GetProfileAsync(Identifier.UserId.Value);
        }
        /// <summary>
        /// 获取当前授权用户的权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<string>> GetPermissions()
        {
            return await _querier.GetPermissionsAsync(Identifier.UserId.Value);
        }

    }
}
