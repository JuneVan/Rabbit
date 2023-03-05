namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public class RoleQuerier : IRoleQuerier
    {
        public Task<RoleModel> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComboboxItemDto>> GetRoleItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<RoleListModel>> GetRolesAsync(GetRolesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
