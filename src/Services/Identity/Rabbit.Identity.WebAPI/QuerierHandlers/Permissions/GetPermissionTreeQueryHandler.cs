namespace Rabbit.Identity.WebAPI.QuerierHandlers.Permissions
{
    public class GetPermissionTreeQueryHandler : IRequestHandler<GetPermissionTreeQuery, List<TreeItemDto>>
    {
        public Task<List<TreeItemDto>> Handle(GetPermissionTreeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
