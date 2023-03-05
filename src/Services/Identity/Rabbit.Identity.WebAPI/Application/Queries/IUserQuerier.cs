namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IUserQuerier
    {
        Task<UserModel> GetUserByIdAsync(int id);
        Task<PagedResultDto<UserListModel>> GetUsersAsync(GetUsersQuery query);
        Task<IEnumerable<ComboboxItemDto>> GetUserItemsAsync();
    }
}
