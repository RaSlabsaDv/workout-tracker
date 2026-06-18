using MediatR;

public class UpdateExerciseCommandHandler
(
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateExerciseCommand>
{
    public async Task Handle(UpdateExerciseCommand request, CancellationToken ct)
    {
        var exercise = await exerciseRepository.GetByIdAsync(request.ExerciseId, ct);

        if (exercise == null)
            throw new NotFoundException($"Exercise {request.ExerciseId} not found");

        if (exercise.UserId != request.UserId || !exercise.IsCustom)
            throw new ForbiddenException("You don't have permission to update this exercise.");

        exercise.Update(request.Name, request.Category);

        await unitOfWork.SaveChangesAsync(ct);
    }
}