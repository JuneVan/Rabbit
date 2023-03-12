namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateBasicAttributeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeValueType ValueType { get; set; }
        public AttributeControlType ControlType { get; set; }
        public string Description { get; set; }
        public bool IsSearch { get; set; }
        public int? UnitId { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public List<AttributeOption> Options { get; set; }
    }
    public class CreateSalesAttributeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public List<AttributeOption> Options { get; set; }
    }

    public class UpdateBasicAttributeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeValueType ValueType { get; set; }
        public AttributeControlType ControlType { get; set; }
        public string Description { get; set; }
        public bool IsSearch { get; set; }
        public int? UnitId { get; set; }
        public bool IsActive { get; set; } 
        public List<AttributeOptionModel> Options { get; set; }
    }
    public class UpdateSalesAttributeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public List<AttributeOptionModel> Options { get; set; }
    }

    public class AttributeOptionModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class DeleteAttributeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
