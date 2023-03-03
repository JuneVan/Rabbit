namespace Rabbit.Authorization.Permissions
{
    /// <summary>
    /// 检查权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckPermissionAttribute : Attribute
    {
        public CheckPermissionAttribute(params string[] permissionNames)
        {
            if (permissionNames == null) throw new ArgumentNullException(nameof(permissionNames), "请设置验证权限名。");
            PermissionNames = permissionNames;
        }
        public string[] PermissionNames { get; set; }
    }
}
