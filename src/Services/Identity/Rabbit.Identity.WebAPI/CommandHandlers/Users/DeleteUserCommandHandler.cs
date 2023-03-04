namespace Rabbit.Identity.WebAPI.CommandHandlers.Users
{
    public class DeleteUserCommandHandler : UserCommandHandlerBase, IRequestHandler<DeleteUserCommand>
    {
        public DeleteUserCommandHandler(
           IServiceProvider serviceProvider,
           IRepository<User> userRepository)
           : base(serviceProvider, userRepository)
        {
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Roles);
            if (user == null)
                throw new EntityNotFoundException(typeof(User), request.Id);
            if (user.IsSystemUser)
                throw new InvalidOperationException($"系统用户不能被删除。");
            await UserRepository.DeleteAsync(user);
            await UserRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
