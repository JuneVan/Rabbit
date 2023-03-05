namespace Rabbit.Authorization
{
    public interface IPermissionProvider
    {
        Task<IList<string>> GetPermissionsAsync(int userId);
    }
}
