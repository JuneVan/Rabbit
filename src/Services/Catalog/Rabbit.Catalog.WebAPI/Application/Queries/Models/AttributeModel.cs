namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class AttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeDisplayType DisplayType { get; set; }
        public List<AttributeOptionModel> Options { get; set; }
    }
    public class AttributeOptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
