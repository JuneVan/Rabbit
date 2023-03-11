namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class GetAttributeGroupsInput : PagedRequestDto
    {
        public int CategoryId { get; set; }
    }
}
