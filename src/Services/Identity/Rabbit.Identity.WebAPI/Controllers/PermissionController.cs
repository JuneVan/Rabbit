using Rabbit.Authorization.Permissions;
using Rabbit.Identity.WebAPI.DTOs.Permissions;
using Rabbit.Identity.WebAPI.Queries.Permissions;

namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [CheckPermission(StandardPermissions.Permissions)]
    public class PermissionController : IdentityControllerBase
    {
        public PermissionController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
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
        /// <param name="query">查询权限参数</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionDto> Get([FromQuery] GetPermissionByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<TreeItemDto>> GetTree()
        {
            return await Mediator.Send(new GetPermissionTreeQuery());
        }

    }
}
