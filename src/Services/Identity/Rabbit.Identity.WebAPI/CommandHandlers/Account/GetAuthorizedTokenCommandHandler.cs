namespace Rabbit.Identity.WebAPI.CommandHandlers.Account
{
    public class GetAuthorizedTokenCommandHandler : IRequestHandler<GetAuthorizedTokenCommand, string>
    {
        private readonly IRepository<User> _userRepository;
        public GetAuthorizedTokenCommandHandler(IOptions<JwtOptions> options,
            IRepository<User> userRepository)
        {
            _options = options?.Value;
            _userRepository = userRepository;
        }
        private readonly JwtOptions _options;
        public async Task<string> Handle(GetAuthorizedTokenCommand request, CancellationToken cancellationToken)
        {
            // 用户名、密码登录检查
            var user = await _userRepository.FirstOrDefaultAsync(f => f.Username == request.Username);
            if (user == null)
                throw new InvalidOperationException($"用户名或密码不正确。");
            var passwordHash = Md5Algorithm.Encrypt(request.Password);
            if (!string.Equals(user.PasswordHash, passwordHash))
                throw new InvalidOperationException($"用户名或密码不正确。");
            if (!user.IsActive)
                throw new InvalidOperationException("用户已被禁止登录。");

            // 创建Token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtTokenBuilder();
            token.AddSecurityKey(JwtSecurityKey.Create(_options.SecretKey));

            if (_options.ValidateIssuer)
                token.AddIssuer(_options.ValidIssuer);
            if (_options.ValidateAudience)
                token.AddAudience(_options.ValidAudience);
            token.AddClaims(claims);
            token.AddExpiry(_options.ExpiryInMinutes);
            var jwtToken = token.Build();
            return jwtToken.Value;
        }
    }
}
