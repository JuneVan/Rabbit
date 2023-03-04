namespace Rabbit.Identity.WebAPI.Commands.Users
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
