namespace Rabbit.Identity.WebAPI.DTOs.Users
{
    public class UserListDto : EntityDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 是否为系统用户
        /// </summary>
        public bool IsSystemUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? LastModifiedTime { get; set; }
    }
}
