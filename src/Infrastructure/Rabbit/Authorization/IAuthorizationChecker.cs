namespace Rabbit.Authorization
{
    public interface IAuthorizationChecker
    {
        Task<bool> AuthorizeAsync(string permissionName);
    }
}
