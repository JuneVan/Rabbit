﻿namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class DeletePermissionCommandHandler : PermissionCommandHandlerBase, IRequestHandler<DeletePermissionCommand>
    {
        public DeletePermissionCommandHandler(
            IServiceProvider serviceProvider,
            IRepository<Permission> permissionRepository)
            : base(serviceProvider, permissionRepository)
        {
        }
        public async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await PermissionRepository.FirstOrDefaultAsync(request.Id);
            if (permission == null)
                throw new EntityNotFoundException(typeof(Permission), request.Id);

            await PermissionRepository.DeleteAsync(permission);
            await PermissionRepository.UnitOfWork.CommitAsync();
        }
    }
}
