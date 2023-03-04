namespace Rabbit.Identity.WebAPI.Commands.Permissions
{
    /// <summary>
    /// 更新权限命令
    /// </summary>
    public class UpdatePermissionCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// 权限名称（唯一标识符）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 上级权限
        /// </summary>
        public int? ParentId { get; set; }
    }

}
