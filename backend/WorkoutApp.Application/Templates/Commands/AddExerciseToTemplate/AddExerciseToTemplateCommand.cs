using MediatR;

public record AddExerciseToTemplateCommand
(
    int UserId,
    int TemplateId,
    TemplateExerciseDto Exercise
) : IRequest;