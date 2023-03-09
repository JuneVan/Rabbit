namespace Rabbit.Identity.WebAPI.Application.Commands
{
    /// <summary>
    /// 创建角色命令
    /// </summary>
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; }
    }
    /// <summary>
    /// 更新角色命令
    /// </summary>
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; }
    }
    /// <summary>
    /// 删除角色命令
    /// </summary>
    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
