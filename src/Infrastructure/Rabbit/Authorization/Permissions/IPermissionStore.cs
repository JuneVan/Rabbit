namespace Rabbit.Authorization.Permissions
{
    public interface IPermissionStore
    {
        Task<IList<string>> GetOrCreatePermissionsAsync(int userId);
    }
}
