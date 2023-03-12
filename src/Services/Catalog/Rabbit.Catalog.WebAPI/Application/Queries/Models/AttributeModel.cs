namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class BasicAttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeValueType ValueType { get; set; }
        public AttributeControlType DisplayType { get; set; }
        public string Description { get; set; }
        public bool IsSearch { get; set; }
        public int? UnitId { get; set; }
        public bool IsActive { get; set; }
        public List<AttributeOptionModel> Options { get; set; }
    }
    public class SalesAttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<AttributeOptionModel> Options { get; set; }
    }
    public class AttributeOptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
