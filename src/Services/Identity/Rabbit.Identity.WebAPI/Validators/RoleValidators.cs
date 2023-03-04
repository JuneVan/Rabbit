namespace Rabbit.Identity.WebAPI.Validators
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("角色名称不能为空。");
            RuleFor(x => x.Description).NotEmpty().WithMessage("角色显示名称不能为空。");
        }
    }

    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("角色名称不能为空。");
            RuleFor(x => x.Description).NotEmpty().WithMessage("角色显示名称不能为空。");
        }
    }
}
