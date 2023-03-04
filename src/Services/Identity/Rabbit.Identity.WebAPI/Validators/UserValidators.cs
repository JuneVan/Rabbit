namespace Rabbit.Identity.WebAPI.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("用户名称不能为空");
            RuleFor(x => x.Password).NotEmpty().WithMessage("密码不能为空");
            RuleFor(x => x.Email).EmailAddress().WithMessage("邮箱格式不正确");
            RuleFor(x => x.Phone).Matches(@"^1\d{10}$").WithMessage("手机号格式不正确");
        }
    }
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("邮箱格式不正确");
            RuleFor(x => x.Phone).Matches(@"^1\d{10}$").WithMessage("手机号格式不正确");
        }
    }
}
