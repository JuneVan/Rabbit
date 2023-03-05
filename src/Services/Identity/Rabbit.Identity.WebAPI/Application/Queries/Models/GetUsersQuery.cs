namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class GetUsersQuery : PagedRequestDto
    {
        public string Username { get; set; }
    }
}
