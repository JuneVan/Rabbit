namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary> 
    [CheckPermission(StandardPermissions.Users)]
    public class UserController : IdentityControllerBase
    {
        public UserController(IServiceProvider serviceProvider)

            : base(serviceProvider)
        {
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="command">用户</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Users_Create)]
        public async Task Create([FromBody] CreateUserCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="command">用户参数</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Users_Update)]
        public async Task Update([FromBody] UpdateUserCommand command)
        {
            await Mediator.Send(command);
            // 发送重新授权事件
            await Task.CompletedTask;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="command">用户参数</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Users_Delete)]
        public async Task Delete([FromBody] DeleteUserCommand command)
        {
            await Mediator.Send(command);
            // 发送重新授权事件
            await Task.CompletedTask;
        }
        /// <summary>
        /// 获取一条用户记录
        /// </summary>
        /// <param name="query">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserDto> Get([FromQuery] GetUserByIdQuery query)
        {
            return await Mediator.Send(query);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<UserListDto>> GetAll([FromQuery] GetUsersQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// 查询可用用户选项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [NoCheckPermission]
        public async Task<List<ComboboxItemDto>> GetComboboxItems()
        {
            return await Mediator.Send(new GetUserItemsQuery());
        }

    }
}
