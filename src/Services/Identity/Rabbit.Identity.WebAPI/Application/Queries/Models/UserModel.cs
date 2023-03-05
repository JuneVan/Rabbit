namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
        public bool IsSystemUser { get; set; }
    }
}
