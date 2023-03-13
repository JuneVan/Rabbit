﻿namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IAccountQuerier
    {
        Task<ProfileModel> GetProfileAsync(int userId);
        Task<IEnumerable<string>> GetPermissionsAsync(int userId);
    }
    public class AccountQuerier : IAccountQuerier
    {
        private readonly IMapper _mapper;
        private readonly IQueryableRepository<User> _userRepository;
        private readonly IQueryableRepository<UserRole> _userRoleRepository; 
        private readonly IQueryableRepository<RolePermission> _rolePermissionRepository;
        private readonly IQueryableRepository<Permission> _permissionRepository;
        private readonly IThreadSignal _signal;
        public AccountQuerier(
            IMapper mapper,
            IQueryableRepository<User> userRepository,
            IQueryableRepository<UserRole> userRoleRepository,
            IQueryableRepository<RolePermission> rolePermissionRepository,
            IQueryableRepository<Permission> permissionRepository,
            IThreadSignal signal)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository; 
            _rolePermissionRepository = rolePermissionRepository;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
            _signal = signal;
        }
        public async Task<IEnumerable<string>> GetPermissionsAsync(int userId)
        {
            var query = from a in _userRoleRepository.GetAll()
                        join b in _rolePermissionRepository.GetAll() on a.RoleId equals b.RoleId
                        join c in _permissionRepository.GetAll() on b.PermissionId equals c.Id
                        select c.Name;

            var permissionNames = await query.ToListAsync(_signal.CancellationToken);
            if (permissionNames == null)
                return null;
            return permissionNames.Distinct().ToList();
        }

        public async Task<ProfileModel> GetProfileAsync(int userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(userId);
            if (user == null)
                throw new EntityNotFoundException(typeof(User), userId);
            return _mapper.Map<ProfileModel>(user);
        }
    }
}
