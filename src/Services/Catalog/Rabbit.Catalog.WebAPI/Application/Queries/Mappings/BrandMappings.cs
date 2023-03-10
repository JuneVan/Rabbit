namespace Rabbit.Catalog.WebAPI.Application.Queries.Mappings
{
    public class BrandMappings : Profile
    {
        public BrandMappings()
        {
            CreateMap<Brand, BrandModel>();
        }
    }
}
