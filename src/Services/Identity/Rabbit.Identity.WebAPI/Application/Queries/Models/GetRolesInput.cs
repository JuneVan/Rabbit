namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class GetRolesInput : PagedRequestDto
    {
        public string Name { get; set; }
    }
}
