using MediatR;

public class ArchiveExerciseCommandHandler
(
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<ArchiveExerciseCommand>
{
    public async Task Handle(ArchiveExerciseCommand request, CancellationToken ct)
    {
        var exercise = await exerciseRepository.GetByIdAsync(request.ExerciseId, ct);

        if (exercise == null)
            throw new NotFoundException($"Exercise {request.ExerciseId} not found");

        if (exercise.UserId != request.UserId || !exercise.IsCustom)
            throw new ForbiddenException("You don't have permission to archive this exercise.");

        exercise.Archive();

        await unitOfWork.SaveChangesAsync(ct);
    }
}