using MediatR;

public record CreateExerciseCommand
(
    string Name, 
    ExerciseCategory Category,
    int? UserId
) : IRequest<int>;