﻿namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class UpdatePermissionCommandHandler : PermissionCommandHandlerBase, IRequestHandler<UpdatePermissionCommand>
    {
        public UpdatePermissionCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<Permission> permissionRepository)
            : base(serviceProvider, permissionRepository)
        {
        }
        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await PermissionRepository.FirstOrDefaultAsync(request.Id);
            if (permission == null)
                throw new EntityNotFoundException(typeof(Permission), request.Id);

            permission.SetName(request.Name);
            permission.SetDescription(request.Description);
            permission.SetParentId(request.ParentId);

            await CheckDuplicatedPermissionAsync(permission);

            await PermissionRepository.UpdateAsync(permission);
            await PermissionRepository.UnitOfWork.CommitAsync();
        }
    }
}
