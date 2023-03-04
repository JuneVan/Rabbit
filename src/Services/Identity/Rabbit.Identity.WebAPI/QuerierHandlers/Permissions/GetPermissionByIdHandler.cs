namespace Rabbit.Identity.WebAPI.QuerierHandlers.Permissions
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, PermissionDto>
    {
        public GetPermissionByIdHandler()
        {
        }

        public Task<PermissionDto> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
