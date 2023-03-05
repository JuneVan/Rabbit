namespace Rabbit.Identity.WebAPI.Application.Commands.Validators
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("权限名称不能为空。");
            RuleFor(x => x.Description).NotEmpty().WithMessage("权限显示名称不能为空。");
        }
    }
    public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
    {
        public UpdatePermissionCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("权限名称不能为空。");
            RuleFor(x => x.Description).NotEmpty().WithMessage("权限显示名称不能为空。");
        }
    }
}
