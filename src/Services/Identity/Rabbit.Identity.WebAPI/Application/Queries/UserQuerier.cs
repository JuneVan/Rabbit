namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public class UserQuerier : IUserQuerier
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public UserQuerier(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                var userModel = await connection.QueryFirstOrDefaultAsync<UserModel>("SELECT \"Username\",\"Email\",\"Phone\",\"IsActive\",\"LastLoginTime\",\"IsSystemUser\" FROM Users WHERE \"Id\"=@Id AND \"IsDeleted\"=0", new { Id = id });
                if (userModel == null)
                    return null;
                userModel.RoleIds = await connection.QueryAsync<int>("SELECT 'RoleId' FROM UserRoles WHERE UserId=@Id", new { Id = id });

                return userModel;
            }
        }

        public async Task<IEnumerable<ComboboxItemDto>> GetUserItemsAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                return await connection.QueryAsync<ComboboxItemDto>("SELECT \"Id\",\"Username\" FROM Users WHERE \"IsDeleted\"=0");
            }
        }

        public async Task<PagedResultDto<UserListModel>> GetUsersAsync(GetUsersQuery query)
        {

            using (var connection = new NpgsqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                var filterSQL = " \"IsDeleted\"=0";

                var totalCount = await connection.QuerySingleOrDefaultAsync($"SELECT COUNT(1) FROM Users WHERE 1=1 AND {filterSQL}");

                var users = await connection.QueryAsync<UserListModel>("SELECT \"Id\",\"Username\",\"Email\",\"Phone\",\"IsActive\",\"LastLoginTime\",\"IsSystemUser\",\"CreatedTime\",\"LastModifiedTime\" FROM Users  WHERE 1=1 AND{filterSQL} LIMIT {query.PageSize} OFFSET {(query.PageIndex - 1) * query.PageSize}");

                return new PagedResultDto<UserListModel>(totalCount, users?.ToList());
            }
        }
    }
}
