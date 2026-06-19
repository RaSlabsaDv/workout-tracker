using MediatR;

public class DeleteTemplateCommandHandler
(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteTemplateCommand>
{
    public async Task Handle(DeleteTemplateCommand request, CancellationToken ct)
    {
        var template = await templateRepository.GetByIdAsync(request.TemplateId, ct);

        if (template == null)
            throw new NotFoundException($"Template {request.TemplateId} not found");

        if (template.UserId != request.UserId)
            throw new ForbiddenException($"You do not have permission to delete this template");

        templateRepository.Remove(template);

        await unitOfWork.SaveChangesAsync(ct);
    }
}