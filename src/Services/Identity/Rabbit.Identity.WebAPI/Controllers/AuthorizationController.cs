namespace Rabbit.Identity.WebAPI.Controllers
{
    /// <summary>
    /// 授权管理
    /// </summary> 
    public class AuthorizationController : IdentityControllerBase
    {
        public AuthorizationController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }
        ///// <summary>
        ///// 获取用户的权限
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[WrapResult(false)]
        //public async Task<List<string>> GetUserPermissions(int userId)
        //{
        //    return await Mediator.Send(new GetPermissionsQuery()
        //    {
        //        UserId = userId
        //    });
        //}
    }
}
