namespace Rabbit.Identity.WebAPI.QuerierHandlers.Roles
{
    public class GetRoleQueryByIdHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        public Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
