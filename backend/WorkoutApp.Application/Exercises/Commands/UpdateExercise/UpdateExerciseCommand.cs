using MediatR;

public record UpdateExerciseCommand
(
    int ExerciseId,
    int UserId,
    string Name, 
    ExerciseCategory Category
) : IRequest;