using FluentValidation;

public class RemoveExerciseFromTemplateCommandValidator : AbstractValidator<RemoveExerciseFromTemplateCommand>
{
    public RemoveExerciseFromTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.TemplateId).GreaterThan(0);
        RuleFor(x => x.TemplateExerciseId).GreaterThan(0);
    }
}