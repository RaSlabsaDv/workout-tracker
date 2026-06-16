using Microsoft.EntityFrameworkCore;

public class TemplateExerciseRepository(WorkoutContext context) : ITemplateExerciseRepository
{
    public async Task AddAsync(TemplateExercise templateExercise, CancellationToken ct = default)
    {
        await context.TemplateExercises.AddAsync(templateExercise, ct);
    }

    public async Task<TemplateExercise?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.TemplateExercises.FindAsync([id], ct);

    public async Task<List<TemplateExercise>> GetByTemplateIdAsync(int templateId, CancellationToken ct = default) =>
        await context.TemplateExercises.Where(te => te.TemplateId == templateId).ToListAsync(ct);

    public void Remove(TemplateExercise templateExercise) =>
        context.TemplateExercises.Remove(templateExercise);
}