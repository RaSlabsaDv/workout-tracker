using MediatR;

public class GetAllExercisesQueryHandler
(
    IExerciseRepository exerciseRepository
) : IRequestHandler<GetAllExercisesQuery, List<ExerciseDto>>
{
    public async Task<List<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken ct)
    {
        var exercises = await exerciseRepository.GetAllAsync(ct);

        return exercises
            .Select(e => new ExerciseDto(e.Id, e.Name, e.Category))
            .ToList();
    }
}