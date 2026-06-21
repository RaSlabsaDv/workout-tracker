using MediatR;

public class ReorderTemplateExerciseCommandHandler
(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<ReorderTemplateExerciseCommand>
{
    public async Task Handle(ReorderTemplateExerciseCommand request, CancellationToken ct)
    {
        var template = await templateRepository.GetByIdAsync(request.TemplateId, ct);

        if (template == null)
            throw new NotFoundException($"Template {request.TemplateId} not found");

        if (template.UserId != request.UserId)
            throw new ForbiddenException($"You do not have permission to update this template");

        foreach(var item in request.Exercises)
        {
            var te = template.Exercises.FirstOrDefault(e => e.Id == item.TemplateExerciseId);

            if(te == null)
                throw new NotFoundException($"TemplateExercise {item.TemplateExerciseId} not found.");

            te.UpdateOrder(item.Order);
        }

        await unitOfWork.SaveChangesAsync(ct);
    }
}