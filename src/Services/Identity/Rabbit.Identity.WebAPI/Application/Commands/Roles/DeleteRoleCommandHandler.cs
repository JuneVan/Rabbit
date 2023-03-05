namespace Rabbit.Identity.WebAPI.Application.Commands.Roles
{
    public class DeleteRoleCommandHandler : RoleCommandHandlerBase, IRequestHandler<DeleteRoleCommand>
    {
        public DeleteRoleCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<Role> roleRepository)
            : base(serviceProvider, roleRepository)
        {
        }
        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await RoleRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Permissions);
            if (role == null)
                throw new EntityNotFoundException(typeof(Role), request.Id);
            if (role.IsSystemRole)
                throw new InvalidOperationException($"系统角色不能被删除。");
            await RoleRepository.DeleteAsync(role);
            await RoleRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
