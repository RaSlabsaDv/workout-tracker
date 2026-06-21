using MediatR;

public record ReorderTemplateExerciseCommand
(
    int TemplateId,
    int UserId,
    List<ExerciseOrderDto> Exercises
) : IRequest;