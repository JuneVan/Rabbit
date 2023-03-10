namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface IBrandQuerier
    {
        Task<BrandModel> GetBrandByIdAsync(int id);
        Task<PagedResultDto<BrandListModel>> GetBrandsAsync(GetBrandsInput input);
    }
}
