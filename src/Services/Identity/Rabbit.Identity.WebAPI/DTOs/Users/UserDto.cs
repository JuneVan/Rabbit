namespace Rabbit.Identity.WebAPI.DTOs.Users
{
    public class UserDto : EntityDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public List<int> RoleIds { get; set; }
        public bool IsSystemUser { get; set; }
    }
}
