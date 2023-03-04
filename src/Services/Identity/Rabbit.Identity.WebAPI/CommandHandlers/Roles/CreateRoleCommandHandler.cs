namespace Rabbit.Identity.WebAPI.CommandHandlers.Roles
{
    public class CreateRoleCommandHandler : RoleCommandHandlerBase, IRequestHandler<CreateRoleCommand>
    {
        public CreateRoleCommandHandler(IServiceProvider serviceProvider,
            IRepository<Role> roleRepository)
            : base(serviceProvider, roleRepository)
        {
        }
        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role(request.Name, request.Description, request.IsActive, false);
            await CheckDuplicatedRoleAsync(role);
            await RoleRepository.InsertAsync(role);
            await RoleRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
