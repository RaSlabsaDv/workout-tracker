using FluentValidation;

public class AddExerciseToTemplateCommandValidator : AbstractValidator<AddExerciseToTemplateCommand>
{
    public AddExerciseToTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.TemplateId).GreaterThan(0);
        RuleFor(x => x.Exercise.ExerciseId).GreaterThan(0);
        RuleFor(x => x.Exercise.DefaultSets).GreaterThan(0);
        RuleFor(x => x.Exercise.DefaultReps).GreaterThan(0);
        RuleFor(x => x.Exercise.DefaultWeight).GreaterThanOrEqualTo(0).When(x => x.Exercise.DefaultWeight.HasValue);
        RuleFor(x => x.Exercise.RestSeconds).GreaterThanOrEqualTo(0);
    }
}