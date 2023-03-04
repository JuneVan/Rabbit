namespace Rabbit.Identity.WebAPI.Queries.Permissions
{
    public class GetPermissionByIdQuery : IRequest<PermissionDto>
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int Id { get; set; }
    }
}
