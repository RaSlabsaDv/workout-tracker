using MediatR;

public class CreateTemplateCommandHandler
(
    ITemplateRepository templateRepository,
    ITemplateExerciseRepository templateExerciseRepository,
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateTemplateCommand, int>
{
    public async Task<int> Handle(CreateTemplateCommand request, CancellationToken ct)
    {
        var template = new Template(request.UserId, request.Name);
        await templateRepository.AddAsync(template, ct);

        await unitOfWork.SaveChangesAsync(ct);

        for (int i = 0; i < request.Exercises.Count; i++)
        {
            var e = request.Exercises[i];
            var exercise = await exerciseRepository.GetByIdAsync(e.ExerciseId, ct);

            if (exercise is null)
                throw new NotFoundException($"Exercise {e.ExerciseId} not found.");

            var templateExercise = new TemplateExercise
            (
                template.Id, e.ExerciseId, e.DefaultSets,
                e.DefaultReps, e.DefaultWeight, e.RestSeconds, i + 1
            );

            await templateExerciseRepository.AddAsync(templateExercise, ct);
        }

        await unitOfWork.SaveChangesAsync(ct);
        
        return template.Id;
    }
}