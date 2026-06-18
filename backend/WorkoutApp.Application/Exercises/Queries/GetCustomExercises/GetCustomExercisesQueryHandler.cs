using MediatR;

public class GetCustomExercisesQueryHandler
(
    IExerciseRepository exerciseRepository
) : IRequestHandler<GetCustomExercisesQuery, List<ExerciseDto>>
{
    public async Task<List<ExerciseDto>> Handle(GetCustomExercisesQuery request, CancellationToken ct)
    {
        var exercises = await exerciseRepository.GetCustomByUserIdAsync(request.UserId, ct);

        return exercises
            .Select(e => new ExerciseDto(e.Id, e.Name, e.Category))
            .ToList();
    }
}