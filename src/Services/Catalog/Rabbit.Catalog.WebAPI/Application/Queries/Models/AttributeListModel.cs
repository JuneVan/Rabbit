namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class AttributeListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeControlType  ControlType { get; set; }
        public string ControlTypeText => ControlType.GetDescription();
        public AttributeValueType ValueType { get; set; }
        public string ValueTypeText => ValueType.GetDescription();
        public AttributeType AttributeType { get; set; }
        public string AttributeTypeText => AttributeType.GetDescription();
        public DateTime CreatedTime { get; set; }
    }
}
