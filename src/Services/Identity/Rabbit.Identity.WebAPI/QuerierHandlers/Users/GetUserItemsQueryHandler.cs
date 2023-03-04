namespace Rabbit.Identity.WebAPI.QuerierHandlers.Users
{
    public class GetUserItemsQueryHandler : IRequestHandler<GetUserItemsQuery, List<ComboboxItemDto>>
    {
        public Task<List<ComboboxItemDto>> Handle(GetUserItemsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
