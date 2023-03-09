namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
