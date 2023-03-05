namespace Rabbit.Identity.WebAPI.Application.Commands.Roles
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
}
