namespace Rabbit.Identity.WebAPI.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
    }
}
