using MediatR;

public record GetCustomExercisesQuery(int UserId) : IRequest<List<ExerciseDto>>;