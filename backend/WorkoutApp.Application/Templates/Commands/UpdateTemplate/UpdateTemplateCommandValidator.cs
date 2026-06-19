using FluentValidation;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.TemplateId).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
    }
}