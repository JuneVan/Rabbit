namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class AttributeListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeDisplayType DisplayType { get; set; }
        public string DisplayTypeText => DisplayType.GetDescription();
        public DateTime CreatedTime { get; set; }
    }
}
