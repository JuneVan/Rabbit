namespace Rabbit.Identity.WebAPI.Application.Commands.Users
{
    public abstract class UserCommandHandlerBase : CommandHandlerBase
    {
        public UserCommandHandlerBase(
            IServiceProvider serviceProvider,
            IRepository<User> userRepository)
            : base(serviceProvider)
        {
            UserRepository = userRepository;
        }
        protected IRepository<User> UserRepository { get; private set; }
        /// <summary>
        /// 检查用户是否已存在于系统
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected virtual async Task CheckDuplidateUserAsync(User user)
        {
            var duplicatedUser = await UserRepository.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                throw new ArgumentException($"用户名`{user.Username}`已存在。");
            // 邮箱检查
            if (!string.IsNullOrEmpty(user.Email))
            {
                duplicatedUser = await UserRepository.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                    throw new ArgumentException($"用户邮箱`{user.Email}`已存在。");
            }
            // 手机号检查
            if (!string.IsNullOrEmpty(user.Phone))
            {
                duplicatedUser = await UserRepository.FirstOrDefaultAsync(x => x.Phone == user.Phone);
                if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                    throw new ArgumentException($"用户手机号`{user.Phone}`已存在。");
            }
        }
    }
}
