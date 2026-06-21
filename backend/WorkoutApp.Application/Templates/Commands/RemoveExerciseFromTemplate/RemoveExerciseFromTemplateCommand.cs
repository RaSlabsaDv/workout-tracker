using MediatR;

public record RemoveExerciseFromTemplateCommand(int UserId, int TemplateId, int TemplateExerciseId) : IRequest;