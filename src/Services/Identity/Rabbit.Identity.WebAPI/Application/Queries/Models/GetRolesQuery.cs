namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class GetRolesQuery : PagedRequestDto
    {
        public string Name { get; set; }
    }
}
