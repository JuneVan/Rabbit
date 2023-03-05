namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IPermissionQuerier
    {
        Task<PermissionModel> GetPermissionByIdAsync(int id);

        Task<IEnumerable<TreeItemDto>> GetPermissionTreeItemsAsync();
    }
}
