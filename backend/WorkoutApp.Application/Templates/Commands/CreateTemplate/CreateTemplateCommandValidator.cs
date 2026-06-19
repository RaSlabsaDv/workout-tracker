using FluentValidation;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        
        RuleForEach(x => x.Exercises).ChildRules(e =>
        {
            e.RuleFor(x => x.ExerciseId).GreaterThan(0);
            e.RuleFor(x => x.DefaultSets).GreaterThan(0);
            e.RuleFor(x => x.DefaultReps).GreaterThan(0);
            e.RuleFor(x => x.DefaultWeight).GreaterThanOrEqualTo(0).When(x => x.DefaultWeight.HasValue);
            e.RuleFor(x => x.RestSeconds).GreaterThanOrEqualTo(0);
        });
    }
}