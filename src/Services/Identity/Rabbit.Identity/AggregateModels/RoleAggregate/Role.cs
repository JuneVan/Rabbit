namespace Rabbit.Identity.AggregateModels.RoleAggregate
{
    public class Role : FullAuditedAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<RolePermission> Permissions { get; private set; }
        public bool IsSystemRole { get; private set; }

        public Role(string name, string description, bool isActive, bool isSystemRole)
        {
            SetName(name);
            SetDescription(description);
            SetIsActive(isActive);
            SetIsSystemRole(isSystemRole);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "角色名不能为空。");
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetIsActive(bool isActive)
        {
            if (IsSystemRole)
                throw new InvalidOperationException("系统角色无法被修改状态。");
            IsActive = isActive;
        }
        public void SetIsSystemRole(bool isSystemRole)
        {
            IsSystemRole = isSystemRole;
        }
        public void AddPermission(int permissionId)
        {
            if (permissionId < 0) throw new ArgumentOutOfRangeException(nameof(permissionId), "权限Id无效。");
            if (Permissions == null) Permissions = new List<RolePermission>();
            Permissions.Add(new RolePermission(permissionId));
        }
        public void RemovePermission(int rolePermissionId)
        {
            if (Permissions == null) return;
            var permission = Permissions.FirstOrDefault(x => x.Id == rolePermissionId);
            if (permission != null)
                Permissions.Remove(permission);
        }
    }
}
