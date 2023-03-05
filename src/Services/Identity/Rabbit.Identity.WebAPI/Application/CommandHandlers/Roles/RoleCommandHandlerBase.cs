namespace Rabbit.Identity.WebAPI.Application.CommandHandlers.Roles
{
    public abstract class RoleCommandHandlerBase : CommandHandlerBase
    {
        public RoleCommandHandlerBase(IServiceProvider serviceProvider,
            IRepository<Role> roleRepository)
            : base(serviceProvider)
        {
            RoleRepository = roleRepository;
        }

        protected IRepository<Role> RoleRepository { get; private set; }

        protected virtual async Task CheckDuplicatedRoleAsync(Role role)
        {
            var duplicatedRole = await RoleRepository.FirstOrDefaultAsync(x => x.Name == role.Name);
            if (duplicatedRole != null && duplicatedRole.Id != role.Id)
                throw new ArgumentException($"角色名`{role.Name}`已存在。");
        }
    }
}
