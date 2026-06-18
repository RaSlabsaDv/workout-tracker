using MediatR;

public class CreateExerciseCommandHandler
(
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateExerciseCommand, int>
{
    public async Task<int> Handle(CreateExerciseCommand request, CancellationToken ct)
    {
        var isCustom = request.UserId.HasValue;

        if (isCustom)
        {
            var exists = await exerciseRepository
                .ExistsByNameAndUserAsync(request.Name, request.UserId!.Value, ct);

            if (exists)
                throw new AlreadyExistsException("Exercise with this name already exists.");
        }

        var exercise = new Exercise(request.Name, request.Category, isCustom, request.UserId);

        await exerciseRepository.AddAsync(exercise, ct);
        await unitOfWork.SaveChangesAsync(ct);

        return exercise.Id;
    }
}