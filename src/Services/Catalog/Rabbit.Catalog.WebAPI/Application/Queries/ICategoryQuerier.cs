namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface ICategoryQuerier
    {
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task<PagedResultDto<CategoryListModel>> GetCategoriesAsync(GetCategoriesInput input);
    }
}
