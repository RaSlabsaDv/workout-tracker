using MediatR;

public record UpdateTemplateCommand(int UserId, int TemplateId, string Name) : IRequest;