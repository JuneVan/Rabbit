using Rabbit.Identity.WebAPI.Application.Queries;

namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [Route("v1/[controller]/[action]")]
    [CheckPermission(StandardPermissions.Permissions)]
    public class PermissionController : IdentityControllerBase
    {
        private readonly IPermissionQuerier _querier;
        public PermissionController(IServiceProvider serviceProvider,
            IPermissionQuerier querier) : base(serviceProvider)
        {
            _querier = querier;
        }
        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="command">权限参数</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Permissions_Create)]
        public async Task Create([FromBody] CreatePermissionCommand command)
        {
            await Mediator.Send(command);
        }

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="command">权限参数</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Permissions_Update)]
        public async Task Update([FromBody] UpdatePermissionCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="command">权限参数</param>
        /// <returns></returns>
        [HttpPost]
        [CheckPermission(StandardPermissions.Permissions_Delete)]
        public async Task Delete([FromBody] DeletePermissionCommand command)
        {
            await Mediator.Send(command);
        }

        /// <summary>
        /// 获取一条权限记录
        /// </summary>
        /// <param name="id">权限Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionModel> Get([FromQuery] int id)
        {
            return await _querier.GetPermissionByIdAsync(id);
        }

        /// <summary>
        /// 获取权限树列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TreeItemDto>> GetTree()
        {
            return await _querier.GetPermissionTreeItemsAsync();
        }

    }
}
