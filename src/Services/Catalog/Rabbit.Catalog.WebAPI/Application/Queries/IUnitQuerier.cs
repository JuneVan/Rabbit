namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface IUnitQuerier
    {
        Task<UnitModel> GetUnitByIdAsync(int id);
        Task<PagedResultDto<UnitListModel>> GetUnitsAsync(GetUnitsInput input);
        Task<List<ComboboxItemDto>> GetUnitItemsAsync();
    }
}
