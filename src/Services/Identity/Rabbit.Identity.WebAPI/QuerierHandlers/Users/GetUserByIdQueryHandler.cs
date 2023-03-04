namespace Rabbit.Identity.WebAPI.QuerierHandlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
