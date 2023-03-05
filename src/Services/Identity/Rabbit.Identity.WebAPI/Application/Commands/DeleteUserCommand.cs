namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
