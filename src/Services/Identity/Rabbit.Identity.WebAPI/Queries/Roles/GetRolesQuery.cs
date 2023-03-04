namespace Rabbit.Identity.WebAPI.Queries.Roles
{
    public class GetRolesQuery : PagedRequestDto, IRequest<PagedResultDto<RoleListDto>>
    {
        public string Keyword { get; set; }
    }
}
