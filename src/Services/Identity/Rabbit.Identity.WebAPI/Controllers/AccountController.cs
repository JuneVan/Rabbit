namespace Rabbit.Identity.WebAPI.Controllers
{
    public class AccountController : IdentityControllerBase
    {
        public AccountController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="command">Token参数</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> GetAuthorizedToken([FromBody] GetAuthorizedTokenCommand command)
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
        public async Task<ProfileDto> GetProfile()
        {
            return await Mediator.Send(new GetProfileQuery()
            {
                UserId = Identifier.UserId.Value
            });
        }
        /// <summary>
        /// 获取当前授权用户的权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<string>> GetPermissions()
        {
            return await Mediator.Send(new GetPermissionsQuery()
            {
                UserId = Identifier.UserId.Value
            });
        }

    }
}
