using MediatR;

public record CreateTemplateCommand
(
    int UserId, 
    string Name, 
    List<TemplateExerciseDto> Exercises
) : IRequest<int>;