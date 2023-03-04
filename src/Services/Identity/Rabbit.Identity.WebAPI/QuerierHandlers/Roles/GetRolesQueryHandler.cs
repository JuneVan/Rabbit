namespace Rabbit.Identity.WebAPI.QuerierHandlers.Roles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, PagedResultDto<RoleListDto>>
    {
        public Task<PagedResultDto<RoleListDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
