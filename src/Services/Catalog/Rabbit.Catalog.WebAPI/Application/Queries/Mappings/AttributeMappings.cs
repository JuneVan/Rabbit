using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.WebAPI.Application.Queries.Mappings
{
    public class AttributeMappings:Profile
    {
        public AttributeMappings()
        {
            CreateMap<Attribute, BasicAttributeModel>();
            CreateMap<Attribute, AttributeListModel>();
        }
    }
}
