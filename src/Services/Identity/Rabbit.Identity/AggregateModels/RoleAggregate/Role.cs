namespace Rabbit.Identity.AggregateModels.RoleAggregate
{
    public class Role : FullAuditedAggregateRoot
    {
        public IReadOnlyList<RolePermission> Permissions => _permissions ??= new List<RolePermission>();
        private string _name;
        public string Name => _name;
        private string _description;
        private bool _isActive;

        private bool _isSystemRole;
        public bool IsSystemRole => _isSystemRole;

        private List<RolePermission> _permissions;
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
            _name = name;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public void SetIsActive(bool isActive)
        {
            if (_isSystemRole)
                throw new InvalidOperationException("系统角色无法被修改状态。");
            _isActive = isActive;
        }
        public void SetIsSystemRole(bool isSystemRole)
        {
            _isSystemRole = isSystemRole;
        }
        public void AddPermission(int permissionId)
        {
            if (permissionId < 0) throw new ArgumentOutOfRangeException(nameof(permissionId), "权限Id无效。");
            if (_permissions == null) _permissions = new List<RolePermission>();
            _permissions.Add(new RolePermission(permissionId));
        }
        public void RemovePermission(int rolePermissionId)
        {
            if (_permissions == null) return;
            var permission = _permissions.FirstOrDefault(x => x.Id == rolePermissionId);
            if (permission != null)
                _permissions.Remove(permission);
        }
    }
}
