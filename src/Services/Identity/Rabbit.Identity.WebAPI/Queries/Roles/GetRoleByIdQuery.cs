namespace Rabbit.Identity.WebAPI.Queries.Roles
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }
}
