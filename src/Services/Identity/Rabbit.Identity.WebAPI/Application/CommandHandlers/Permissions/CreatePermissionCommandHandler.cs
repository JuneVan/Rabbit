namespace Rabbit.Identity.WebAPI.Application.CommandHandlers.Permissions
{
    public class CreatePermissionCommandHandler : PermissionCommandHandlerBase, IRequestHandler<CreatePermissionCommand>
    {
        public CreatePermissionCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<Permission> permissionRepository)
            : base(serviceProvider, permissionRepository)
        {
        }
        public async Task<Unit> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission(request.Name, request.Description, request.ParentId);
            await CheckDuplicatedPermissionAsync(permission);

            await PermissionRepository.InsertAsync(permission);
            await PermissionRepository.UnitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
