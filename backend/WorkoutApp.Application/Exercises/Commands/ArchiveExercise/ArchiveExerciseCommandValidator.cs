using FluentValidation;

public class ArchiveExerciseCommandValidator : AbstractValidator<ArchiveExerciseCommand>
{
    public ArchiveExerciseCommandValidator()
    {
        RuleFor(x => x.ExerciseId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}