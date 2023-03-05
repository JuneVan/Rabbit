namespace Rabbit.Identity.WebAPI.Application.Commands
{
    /// <summary>
    /// 删除角色命令
    /// </summary>
    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
