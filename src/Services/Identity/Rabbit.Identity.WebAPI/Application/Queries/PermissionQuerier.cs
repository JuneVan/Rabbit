namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IPermissionQuerier
    {
        Task<PermissionModel> GetPermissionByIdAsync(int id);

        Task<IEnumerable<TreeItemDto>> GetPermissionTreeItemsAsync();
    }
    public class PermissionQuerier : IPermissionQuerier
    {
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionQuerier(IRepository<Permission> permissionRepository,
            IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<PermissionModel> GetPermissionByIdAsync(int id)
        {
            var permission = await _permissionRepository.FirstOrDefaultAsync(id);
            return _mapper.Map<PermissionModel>(permission);
        }

        public async Task<IEnumerable<TreeItemDto>> GetPermissionTreeItemsAsync()
        {
            var query = _permissionRepository.GetAll();
            var permissions = await query.ToListAsync();
            return GetPermissionTree(permissions, null);
        }
        private List<TreeItemDto> GetPermissionTree(List<Permission> permissions, int? parentId)
        {
            var permissionTreeDtos = new List<TreeItemDto>();
            var children = permissions.Where(w => w.ParentId == parentId);
            foreach (var child in children)
            {
                var permissionTreeDto = new TreeItemDto(child.Id, child.Name);
                permissionTreeDto.Children = GetPermissionTree(permissions, child.Id);
                permissionTreeDtos.Add(permissionTreeDto);
            }
            return permissionTreeDtos;
        }
    }
}
