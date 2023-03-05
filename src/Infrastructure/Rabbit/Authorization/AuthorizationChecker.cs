namespace Rabbit.Authorization
{
    public class AuthorizationChecker : IAuthorizationChecker
    {
        private readonly IIdentifier _identifier;
        private readonly IPermissionProvider _permissionStore;
        public AuthorizationChecker(IIdentifier identifier,
          IPermissionProvider permissionStore)
        {
            _identifier = identifier;
            _permissionStore = permissionStore;
        }
        public virtual async Task<bool> AuthorizeAsync(string permissionName)
        {
            if (permissionName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(permissionName), "权限名不能为空。");
            if (!_identifier.UserId.HasValue)
                throw new AuthorizationException("用户未登录");

            var permissions = await _permissionStore.GetPermissionsAsync(_identifier.UserId.Value);
            if (permissions == null || !permissions.Contains(permissionName))
                return false;
            return true;
        }
    }
}
