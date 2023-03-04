namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [CheckPermission(StandardPermissions.Roles)]
    public class RoleController : IdentityControllerBase
    {
        public RoleController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
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
        /// <param name="query">查询角色参数</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<RoleDto> Get([FromQuery] GetRoleByIdQuery query)
        {
            return await Mediator.Send(query);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<RoleListDto>> GetAll([FromQuery] GetRolesQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// 查询可用角色选项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [NoCheckPermission]
        public async Task<List<ComboboxItemDto>> GetComboboxItems()
        {
            return await Mediator.Send(new GetRoleItemsQuery());
        }
    }
}
