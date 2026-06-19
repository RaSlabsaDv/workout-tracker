using MediatR;

public record DeleteTemplateCommand(int UserId, int TemplateId) : IRequest;