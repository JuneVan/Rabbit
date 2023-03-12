using Unit = Rabbit.Catalog.AggregateModels.UnitAggregate.Unit;

namespace Rabbit.Catalog.WebAPI.Application.Queries.Mappings
{
    public class UnitMappings:Profile
    {
        public UnitMappings()
        {
            CreateMap<Unit, UnitModel>();
            CreateMap<Unit, UnitListModel>();
        }
    }
}
