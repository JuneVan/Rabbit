namespace Rabbit.Identity.WebAPI.Application.Commands
{
    public class UserCommandHandlers : IRequestHandler<CreateUserCommand>, IRequestHandler<UpdateUserCommand>, IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository<User> _userRepository;
        public UserCommandHandlers( 
           IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 检查用户是否已存在于系统
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected virtual async Task CheckDuplidateUserAsync(User user)
        {
            var duplicatedUser = await _userRepository.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                throw new ArgumentException($"用户名`{user.Username}`已存在。");
            // 邮箱检查
            if (!string.IsNullOrEmpty(user.Email))
            {
                duplicatedUser = await _userRepository.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                    throw new ArgumentException($"用户邮箱`{user.Email}`已存在。");
            }
            // 手机号检查
            if (!string.IsNullOrEmpty(user.Phone))
            {
                duplicatedUser = await _userRepository.FirstOrDefaultAsync(x => x.Phone == user.Phone);
                if (duplicatedUser != null && duplicatedUser.Id != user.Id)
                    throw new ArgumentException($"用户手机号`{user.Phone}`已存在。");
            }
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Username);
            user.SetPasswordHash(Md5Algorithm.Encrypt(request.Password));
            user.SetIsActive(request.IsActive);
            user.SetEmail(request.Email);
            user.SetPhone(request.Phone);
            user.SetFullName(request.FullName);
            if (request.RoleIds != null)
            {
                foreach (var roleId in request.RoleIds)
                {
                    user.AddRole(roleId);
                }
            }
            await CheckDuplidateUserAsync(user);
            await _userRepository.InsertAsync(user);
            await _userRepository.UnitOfWork.CommitAsync();
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Roles);
            if (user == null)
                throw new EntityNotFoundException(typeof(User), request.Id);
            user.SetEmail(request.Email);
            user.SetPhone(request.Phone);
            user.SetIsActive(request.IsActive);
            user.SetFullName(request.FullName);
            // 清除原有的旧记录
            foreach (var role in user.Roles)
            {
                user.RemoveRole(role.Id);
            }
            // 新增记录
            if (request.RoleIds != null)
            {
                foreach (var roleId in request.RoleIds)
                    user.AddRole(roleId);
            }
            await CheckDuplidateUserAsync(user);
            await _userRepository.UpdateAsync(user);
            await _userRepository.UnitOfWork.CommitAsync();
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Roles);
            if (user == null)
                throw new EntityNotFoundException(typeof(User), request.Id);
            if (user.IsSystemUser)
                throw new InvalidOperationException($"系统用户不能被删除。");
            await _userRepository.DeleteAsync(user);
            await _userRepository.UnitOfWork.CommitAsync();
        }
    }
}
