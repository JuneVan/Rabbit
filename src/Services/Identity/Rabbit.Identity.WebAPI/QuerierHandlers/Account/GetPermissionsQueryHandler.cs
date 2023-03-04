namespace Rabbit.Identity.WebAPI.QuerierHandlers.Account
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<string>>
    {
        public Task<List<string>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
