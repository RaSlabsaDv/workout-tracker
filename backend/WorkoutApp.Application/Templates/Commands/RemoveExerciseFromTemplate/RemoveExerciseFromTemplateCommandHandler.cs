using MediatR;

public class RemoveExerciseFromTemplateCommandHandler
(
    ITemplateRepository templateRepository,
    ITemplateExerciseRepository templateExerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<RemoveExerciseFromTemplateCommand>
{
    public async Task Handle(RemoveExerciseFromTemplateCommand request, CancellationToken ct)
    {
       var template = await templateRepository.GetByIdAsync(request.TemplateId, ct);

        if (template == null)
            throw new NotFoundException($"Template {request.TemplateId} not found");

        if (template.UserId != request.UserId)
            throw new ForbiddenException($"You do not have permission to update this template");

        var templateExercise = template.Exercises.FirstOrDefault(e => e.Id == request.TemplateExerciseId);

        if (templateExercise == null)
            throw new NotFoundException($"Exercise {request.TemplateExerciseId} not found in template.");

        templateExerciseRepository.Remove(templateExercise);

        await unitOfWork.SaveChangesAsync(ct);
    }
}