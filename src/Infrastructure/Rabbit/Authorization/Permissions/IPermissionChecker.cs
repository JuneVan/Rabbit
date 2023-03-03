namespace Rabbit.Authorization.Permissions
{
    public interface IPermissionChecker
    {
        Task<bool> AuthorizeAsync(string permissionName);
    }
}
