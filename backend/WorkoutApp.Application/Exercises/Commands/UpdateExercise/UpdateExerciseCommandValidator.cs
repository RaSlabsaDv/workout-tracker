using FluentValidation;

public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
{
    public UpdateExerciseCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(150);
        RuleFor(x => x.Category).IsInEnum();
        RuleFor(x => x.ExerciseId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}