namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public class PermissionQuerier : IPermissionQuerier
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public PermissionQuerier(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }
        public async Task<PermissionModel> GetPermissionByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                return await connection.QueryFirstOrDefaultAsync<PermissionModel>(@$"SELECT Name,Description,ParentId FROM Permissions WHERE Id=@Id AND IsDeleted=0", new { Id = id });
            }
        }

        public async Task<IEnumerable<TreeItemDto>> GetPermissionTreeItemsAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                var permissions = await connection.QueryFirstOrDefaultAsync<dynamic>(@$"SELECT Id,Name,ParentId FROM Permissions AND IsDeleted=0");
                return GetPermissionTree(permissions, null);
            }
        }
        private List<TreeItemDto> GetPermissionTree(List<dynamic> permissions, int? parentId)
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
