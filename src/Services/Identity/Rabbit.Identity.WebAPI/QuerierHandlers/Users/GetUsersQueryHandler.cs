namespace Rabbit.Identity.WebAPI.QuerierHandlers.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResultDto<UserListDto>>
    {
        public Task<PagedResultDto<UserListDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
