namespace Rabbit.Identity.WebAPI.Commands.Permissions
{
    /// <summary>
    /// 删除权限命令
    /// </summary>
    public class DeletePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
