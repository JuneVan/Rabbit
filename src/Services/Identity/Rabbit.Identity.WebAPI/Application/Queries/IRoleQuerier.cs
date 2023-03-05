namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IRoleQuerier
    {
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<PagedResultDto<RoleListModel>> GetRolesAsync(GetRolesQuery query);
        Task<IEnumerable<ComboboxItemDto>> GetRoleItemsAsync();
    }
}
