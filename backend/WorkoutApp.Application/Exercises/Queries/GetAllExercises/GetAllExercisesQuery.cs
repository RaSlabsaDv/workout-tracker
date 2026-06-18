using MediatR;

public record GetAllExercisesQuery : IRequest<List<ExerciseDto>>;