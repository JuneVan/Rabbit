namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class GetUsersInput : PagedRequestDto
    {
        public string Username { get; set; }
    }
}
