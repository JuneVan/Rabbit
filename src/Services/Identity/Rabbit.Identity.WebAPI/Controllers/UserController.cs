using Rabbit.Identity.WebAPI.Application.Queries;

namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary> 
    [Route("v1/[controller]/[action]")]
    [CheckPermission(StandardPermissions.Users)]
    public class UserController : IdentityControllerBase
    {
        private readonly IUserQuerier _querier;
        public UserController(IServiceProvider serviceProvider,
            IUserQuerier querier)

            : base(serviceProvider)
        {
            _querier = querier;
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
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserModel> Get([FromQuery] int id)
        {
            return await _querier.GetUserByIdAsync(id);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<UserListModel>> GetAll([FromQuery] GetUsersQuery query)
        {
            return await _querier.GetUsersAsync(query);
        }

        /// <summary>
        /// 查询可用用户选项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [NoCheckPermission]
        public async Task<IEnumerable<ComboboxItemDto>> GetItems()
        {
            return await _querier.GetUserItemsAsync();
        }

    }
}
