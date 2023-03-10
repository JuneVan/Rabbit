namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<int> RoleIds { get; set; }
    }

    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<int> RoleIds { get; set; }
    }
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
