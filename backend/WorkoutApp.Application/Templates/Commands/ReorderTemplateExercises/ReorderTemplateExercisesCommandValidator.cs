using System.Security.Cryptography.X509Certificates;
using FluentValidation;

public class ReorderTemplateExerciseCommandValidator : AbstractValidator<ReorderTemplateExerciseCommand>
{
    public ReorderTemplateExerciseCommandValidator()
    {
        RuleFor(x => x.TemplateId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.Exercises).NotEmpty();
        
        RuleForEach(x => x.Exercises).ChildRules(e =>
        {
            e.RuleFor(x => x.TemplateExerciseId).GreaterThan(0);
            e.RuleFor(x => x.Order).GreaterThan(0);
        });
    }
}