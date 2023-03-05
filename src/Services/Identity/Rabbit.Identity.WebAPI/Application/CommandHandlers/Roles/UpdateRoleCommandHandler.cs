namespace Rabbit.Identity.WebAPI.Application.CommandHandlers.Roles
{
    public class UpdateRoleCommandHandler : RoleCommandHandlerBase, IRequestHandler<UpdateRoleCommand>
    {
        public UpdateRoleCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<Role> roleRepository)
            : base(serviceProvider, roleRepository)
        {
        }
        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await RoleRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Permissions);
            if (role == null)
                throw new EntityNotFoundException(typeof(Role), request.Id);
            role.SetName(request.Name);
            role.SetDescription(request.Description);
            role.SetIsActive(request.IsActive);
            await CheckDuplicatedRoleAsync(role);
            await RoleRepository.UpdateAsync(role);
            await RoleRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
