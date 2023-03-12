using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;
using AttributeOptionModel = Rabbit.Catalog.WebAPI.Application.Queries.Models.AttributeOptionModel;

namespace Rabbit.Catalog.WebAPI.Application.Queries.Mappings
{
    public class AttributeMappings:Profile
    {
        public AttributeMappings()
        {
            CreateMap<Attribute, BasicAttributeModel>();
            CreateMap<Attribute, SalesAttributeModel>();
            CreateMap<Attribute, AttributeListModel>();
            CreateMap<AttributeOption, AttributeOptionModel>();
        }
    }
}
