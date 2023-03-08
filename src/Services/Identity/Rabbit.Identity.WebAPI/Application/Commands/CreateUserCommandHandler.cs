namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class CreateUserCommandHandler : UserCommandHandlerBase, IRequestHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<User> userRepository)
            : base(serviceProvider, userRepository)
        {
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Username);
            user.SetPasswordHash(Md5Algorithm.Encrypt(request.Password));
            user.SetIsActive(request.IsActive);
            user.SetEmail(request.Email);
            user.SetPhone(request.Phone);
            user.SetFullName(request.FullName);
            if (request.RoleIds != null)
            {
                foreach (var roleId in request.RoleIds)
                {
                    user.AddRole(roleId);
                }
            }
            await CheckDuplidateUserAsync(user);
            await UserRepository.InsertAsync(user);
            await UserRepository.UnitOfWork.CommitAsync();
        }
    }
}
