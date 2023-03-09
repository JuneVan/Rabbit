namespace Rabbit.Catalog.WebAPI.Application.Queries.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<Category, CategoryListModel>();
        }
    }
}
