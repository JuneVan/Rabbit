namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public   class PermissionCommandHandlers : IRequestHandler<CreatePermissionCommand>, IRequestHandler<UpdatePermissionCommand>, IRequestHandler<DeletePermissionCommand>
    {
        private readonly IRepository<Permission> _permissionRepository;
        public PermissionCommandHandlers( 
            IRepository<Permission> permissionRepository) 
        {
            _permissionRepository = permissionRepository;
        }
        /// <summary>
        /// 检查权限是否存在
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        protected async virtual Task CheckDuplicatedPermissionAsync(Permission permission)
        {
            var duplicatedPermission = await _permissionRepository.FirstOrDefaultAsync(x => x.Name == permission.Name);
            if (duplicatedPermission != null && duplicatedPermission.Id != permission.Id)
                throw new ArgumentException($"权限名`{permission.Name}`已存在。");
        } 

        public async Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission(request.Name, request.Description, request.ParentId);
            await CheckDuplicatedPermissionAsync(permission);

            await _permissionRepository.InsertAsync(permission);
            await _permissionRepository.UnitOfWork.CommitAsync();
        }
        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.FirstOrDefaultAsync(request.Id);
            if (permission == null)
                throw new EntityNotFoundException(typeof(Permission), request.Id);

            permission.SetName(request.Name);
            permission.SetDescription(request.Description);
            permission.SetParentId(request.ParentId);

            await CheckDuplicatedPermissionAsync(permission);

            await _permissionRepository.UpdateAsync(permission);
            await _permissionRepository.UnitOfWork.CommitAsync();
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
