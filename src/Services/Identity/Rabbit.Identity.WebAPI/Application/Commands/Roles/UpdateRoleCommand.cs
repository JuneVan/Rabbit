namespace Rabbit.Identity.WebAPI.Application.Commands.Roles
{

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
}
