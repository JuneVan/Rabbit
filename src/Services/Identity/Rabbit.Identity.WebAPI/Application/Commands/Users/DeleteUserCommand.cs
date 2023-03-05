namespace Rabbit.Identity.WebAPI.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
