namespace Rabbit.Identity.WebAPI.Commands.Account
{
    public class GetAuthorizedTokenCommand : IRequest<string>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
