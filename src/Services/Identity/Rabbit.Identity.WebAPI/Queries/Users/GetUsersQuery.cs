namespace Rabbit.Identity.WebAPI.Queries.Users
{
    public class GetUsersQuery : PagedRequestDto, IRequest<PagedResultDto<UserListDto>>
    {
        public string Keyword { get; set; }
    }
}
