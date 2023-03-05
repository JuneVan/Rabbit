namespace Rabbit.Identity.AggregateModels.UserAggregate
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : FullAuditedAggregateRoot
    {
        /// <summary>
        /// 账户名
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// 密码（加密后的密文）
        /// </summary>
        public string PasswordHash { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        /// <remarks>
        /// true为账户可用，否则不可用
        /// </remarks>
        public bool IsActive { get; private set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; private set; }
        /// <summary>
        /// 关联角色
        /// </summary>
        public ICollection<UserRole> Roles { get; private set; }
        /// <summary>
        /// 是否为系统用户
        /// </summary>
        /// <remarks>
        /// true为系统用户，不可删除，否则为普通用户
        /// </remarks>
        public bool IsSystemUser { get; private set; }


        public User(string username)
        {
            SetUserName(username);
        }
        public void SetUserName(string username)
        {
            if (username == null) throw new ArgumentNullException("username", "用户名不能为空。");
            Username = username;
        }
        public void SetPasswordHash(string passwordHash)
        {
            if (passwordHash == null) throw new ArgumentNullException("password", "密码不能设置为空。");
            PasswordHash = passwordHash;
        }
        public void SetFullName(string fullName)
        {
            FullName = fullName;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetPhone(string phone)
        {
            Phone = phone;
        }
        public void SetIsActive(bool isActive)
        {
            if (IsSystemUser)
                throw new InvalidOperationException("系统用户无法被修改状态。");
            IsActive = isActive;
        }
        public void SetLastLoginTime(DateTime lastLoginTime)
        {
            LastLoginTime = lastLoginTime;
        }
        public void SetIsSystemUser(bool isSystemUser)
        {
            IsSystemUser = isSystemUser;
        }
        public void AddRole(int roleId)
        {
            if (roleId < 0) throw new ArgumentOutOfRangeException(nameof(roleId), "角色Id无效。");
            if (Roles == null) Roles = new List<UserRole>();
            Roles.Add(new UserRole(roleId));
        }
        public void RemoveRole(int userRoleId)
        {
            if (Roles == null) return;
            var role = Roles.FirstOrDefault(x => x.Id == userRoleId);
            Roles.Remove(role);
        }
    }
}
