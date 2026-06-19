using MediatR;

public class AddExerciseToTemplateCommandHandler
(
    ITemplateRepository templateRepository,
    ITemplateExerciseRepository templateExerciseRepository,
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<AddExerciseToTemplateCommand>
{
    public async Task Handle(AddExerciseToTemplateCommand request, CancellationToken ct)
    {
        var template = await templateRepository.GetByIdAsync(request.TemplateId, ct);

        if (template == null)
            throw new NotFoundException($"Template {request.TemplateId} not found");

        if (template.UserId != request.UserId)
            throw new ForbiddenException($"You do not have permission to update this template");

        var exercise = await exerciseRepository.GetByIdAsync(request.Exercise.ExerciseId, ct);

        if(exercise == null)
            throw new AlreadyExistsException("This exercise already exists in template.");

        if (template.Exercises.Any(e => e.ExerciseId == request.Exercise.ExerciseId))
            throw new Exception("Exercises cannot be duplicated");

        var order = template.Exercises.Count + 1;

        await templateExerciseRepository.AddAsync(new TemplateExercise
            (
                request.TemplateId, 
                request.Exercise.ExerciseId, 
                request.Exercise.DefaultSets,
                request.Exercise.DefaultReps,
                request.Exercise.DefaultWeight,
                request.Exercise.RestSeconds,
                order
            ), ct);

        await unitOfWork.SaveChangesAsync(ct);
    }
}