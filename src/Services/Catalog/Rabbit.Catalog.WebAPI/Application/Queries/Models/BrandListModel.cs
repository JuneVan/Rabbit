namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class BrandListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public DateTime  CreatedTime { get; set; }
    }
}
