namespace Rabbit.Identity.WebAPI.Queries.Account
{
    public class GetPermissionsQuery : IRequest<List<string>>
    {
        public int UserId { get; set; }
    }
}
