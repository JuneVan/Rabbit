namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public   class RoleCommandHandlers : IRequestHandler<UpdateRoleCommand>, 
        IRequestHandler<CreateRoleCommand>, 
        IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleCommandHandlers( 
            IRepository<Role> roleRepository) 
        {
            _roleRepository = roleRepository;
        }
         

        protected virtual async Task CheckDuplicatedRoleAsync(Role role)
        {
            var duplicatedRole = await _roleRepository.FirstOrDefaultAsync(x => x.Name == role.Name);
            if (duplicatedRole != null && duplicatedRole.Id != role.Id)
                throw new ArgumentException($"角色名`{role.Name}`已存在。");
        }
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role(request.Name, request.Description, request.IsActive, false);
            await CheckDuplicatedRoleAsync(role);
            await _roleRepository.InsertAsync(role);
            await _roleRepository.UnitOfWork.CommitAsync();
        }
        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Permissions);
            if (role == null)
                throw new EntityNotFoundException(typeof(Role), request.Id);
            role.SetName(request.Name);
            role.SetDescription(request.Description);
            role.SetIsActive(request.IsActive);
            await CheckDuplicatedRoleAsync(role);
            await _roleRepository.UpdateAsync(role);
            await _roleRepository.UnitOfWork.CommitAsync();
        }
       
        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Permissions);
            if (role == null)
                throw new EntityNotFoundException(typeof(Role), request.Id);
            if (role.IsSystemRole)
                throw new InvalidOperationException($"系统角色不能被删除。");
            await _roleRepository.DeleteAsync(role);
            await _roleRepository.UnitOfWork.CommitAsync();
        }
    }
}
