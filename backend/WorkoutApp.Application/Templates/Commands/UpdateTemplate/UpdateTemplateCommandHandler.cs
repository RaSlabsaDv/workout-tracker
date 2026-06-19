using MediatR;

public class UpdateTemplateCommandHandler
(
    ITemplateRepository templateRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateTemplateCommand>
{
    public async Task Handle(UpdateTemplateCommand request, CancellationToken ct)
    {
        var template = await templateRepository.GetByIdAsync(request.TemplateId, ct);

        if (template == null)
            throw new NotFoundException($"Template {request.TemplateId} not found");

        if (template.UserId != request.UserId)
            throw new ForbiddenException($"You do not have permission to update this template");

        template.UpdateName(request.Name);

        await unitOfWork.SaveChangesAsync(ct);
    }
}