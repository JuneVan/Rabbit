namespace Rabbit.Identity.WebAPI.Commands.Users
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
