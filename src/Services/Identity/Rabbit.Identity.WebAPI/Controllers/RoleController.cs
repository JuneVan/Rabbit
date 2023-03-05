using Rabbit.Identity.WebAPI.Application.Commands;

namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Route("v1/[controller]/[action]")]
    [CheckPermission(StandardPermissions.Roles)]
    public class RoleController : IdentityControllerBase
    {
        private readonly IRoleQuerier _querier;
        public RoleController(IServiceProvider serviceProvider, IRoleQuerier querier)
            : base(serviceProvider)
        {
            _querier = querier;
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Roles_Create)]
        public async Task Create([FromBody] CreateRoleCommand role)
        {
            await Mediator.Send(role);
        }

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Roles_Update)]
        public async Task Update([FromBody] UpdateRoleCommand role)
        {
            await Mediator.Send(role);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Roles_Delete)]
        public async Task Delete([FromBody] DeleteRoleCommand role)
        {
            await Mediator.Send(role);
        }
        /// <summary>
        /// 获取一条角色信息
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<RoleModel> Get([FromQuery] int id)
        {
            return await _querier.GetRoleByIdAsync(id);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<RoleListModel>> GetAll([FromQuery] GetRolesQuery query)
        {
            return await _querier.GetRolesAsync(query);
        }

        /// <summary>
        /// 查询可用角色选项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [NoCheckPermission]
        public async Task<IEnumerable<ComboboxItemDto>> GetItems()
        {
            return await _querier.GetRoleItemsAsync();
        }
    }
}
