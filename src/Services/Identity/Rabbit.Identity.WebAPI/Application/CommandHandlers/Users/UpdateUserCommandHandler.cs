namespace Rabbit.Identity.WebAPI.Application.CommandHandlers.Users
{
    public class UpdateUserCommandHandler : UserCommandHandlerBase, IRequestHandler<UpdateUserCommand>
    {
        public UpdateUserCommandHandler(
           IServiceProvider serviceProvider,
           IRepository<User> userRepository)
           : base(serviceProvider, userRepository)
        {
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Roles);
            if (user == null)
                throw new EntityNotFoundException(typeof(User), request.Id);
            user.SetEmail(request.Email);
            user.SetPhone(request.Phone);
            user.SetIsActive(request.IsActive);
            user.SetFullName(request.FullName);
            // 清除原有的旧记录
            foreach (var role in user.Roles)
            {
                user.RemoveRole(role.Id);
            }
            // 新增记录
            if (request.RoleIds != null)
            {
                foreach (var roleId in request.RoleIds)
                    user.AddRole(roleId);
            }
            await CheckDuplidateUserAsync(user);
            await UserRepository.UpdateAsync(user);
            await UserRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
