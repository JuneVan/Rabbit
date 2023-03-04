namespace Rabbit.Identity.WebAPI.Queries.Account
{
    public class GetProfileQuery : IRequest<ProfileDto>
    {
        public int UserId { get; set; }
    }
}
