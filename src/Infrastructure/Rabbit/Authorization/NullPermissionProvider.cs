namespace Rabbit.Authorization
{
    public class NullPermissionProvider : IPermissionProvider
    {
        public Task ClearPermissionsAsync(int userId)
        {
            throw new NotImplementedException("未实现`IPermissionStore`接口。");
        }

        public Task<IList<string>> GetPermissionsAsync(int userId)
        {
            throw new NotImplementedException("未实现`IPermissionStore`接口。");
        }
    }
}
