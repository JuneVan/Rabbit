namespace Rabbit.Identity.WebAPI.QuerierHandlers.Roles
{
    public class GetRoleItemsQueryHandler : IRequestHandler<GetRoleItemsQuery, List<ComboboxItemDto>>
    {
        public Task<List<ComboboxItemDto>> Handle(GetRoleItemsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
