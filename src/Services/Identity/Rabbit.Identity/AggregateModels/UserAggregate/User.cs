namespace Rabbit.Identity.AggregateModels.UserAggregate
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : FullAuditedAggregateRoot
    {
        // 账户名
        private string _username;
        public string Username => _username;
        private string _fullName;
        // 密码（加密后的密文）
        private string _passwordHash;
        public string PasswordHash => _passwordHash;
        // 邮箱
        private string _email;
        public string Email => _email;
        // 手机号码
        private string _phone;
        public string Phone => _phone;
        // 是否可用
        private bool _isActive;
        public bool IsActive => _isActive;
        // 最后登录时间
        private DateTime? _lastLoginTime;
        private List<UserRole> _roles;
        public IReadOnlyList<UserRole> Roles => _roles ??= new List<UserRole>();
        // 是否为系统用户 系统用户，不可删除，否则为普通用户
        private bool _isSystemUser;
        public bool IsSystemUser => _isSystemUser;


        public User(string username)
        {
            SetUserName(username);
        }
        public void SetUserName(string username)
        {
            if (username == null) throw new ArgumentNullException("username", "用户名不能为空。");
            _username = username;
        }
        public void SetPasswordHash(string passwordHash)
        {
            if (_passwordHash == null) throw new ArgumentNullException("password", "密码不能设置为空。");
            _passwordHash = passwordHash;
        }
        public void SetFullName(string fullName)
        {
            _fullName = fullName;
        }
        public void SetEmail(string email)
        {
            _email = email;
        }
        public void SetPhone(string phone)
        {
            _phone = phone;
        }
        public void SetIsActive(bool isActive)
        {
            if (_isSystemUser)
                throw new InvalidOperationException("系统用户无法被修改状态。");
            _isActive = isActive;
        }
        public void SetLastLoginTime(DateTime lastLoginTime)
        {
            _lastLoginTime = lastLoginTime;
        }
        public void SetIsSystemUser(bool isSystemUser)
        {
            _isSystemUser = isSystemUser;
        }
        public void AddRole(int roleId)
        {
            if (roleId < 0) throw new ArgumentOutOfRangeException(nameof(roleId), "角色Id无效。");
            if (_roles == null) _roles = new List<UserRole>();
            _roles.Add(new UserRole(roleId));
        }
        public void RemoveRole(int userRoleId)
        {
            if (_roles == null) return;
            var role = _roles.FirstOrDefault(x => x.Id == userRoleId);
            _roles.Remove(role);
        }
    }
}
