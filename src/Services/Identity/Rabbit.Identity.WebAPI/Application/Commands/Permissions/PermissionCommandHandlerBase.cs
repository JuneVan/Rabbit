namespace Rabbit.Identity.WebAPI.Application.Commands.Permissions
{
    public abstract class PermissionCommandHandlerBase : CommandHandlerBase
    {
        public PermissionCommandHandlerBase(
            IServiceProvider serviceProvider,
            IRepository<Permission> permissionRepository)
            : base(serviceProvider)
        {
            PermissionRepository = permissionRepository;
        }
        protected IRepository<Permission> PermissionRepository { get; private set; }
        /// <summary>
        /// 检查权限是否存在
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        protected async virtual Task CheckDuplicatedPermissionAsync(Permission permission)
        {
            var duplicatedPermission = await PermissionRepository.FirstOrDefaultAsync(x => x.Name == permission.Name);
            if (duplicatedPermission != null && duplicatedPermission.Id != permission.Id)
                throw new ArgumentException($"权限名`{permission.Name}`已存在。");
        }

    }
}
