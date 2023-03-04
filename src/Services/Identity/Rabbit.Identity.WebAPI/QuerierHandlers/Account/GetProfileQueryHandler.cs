namespace Rabbit.Identity.WebAPI.QuerierHandlers.Account
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        public Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
