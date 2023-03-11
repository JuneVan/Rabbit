namespace Rabbit.Catalog.WebAPI.Application.Commands.Validators
{
    public class CreateUnitCommandValidator : AbstractValidator<CreateUnitCommand>
    {
        public CreateUnitCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("单位名称不能为空。");
        }
    }
    public class UpdateUnitCommandValidator : AbstractValidator<UpdateUnitCommand>
    {
        public UpdateUnitCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("单位名称不能为空。");
        }
    }
}
