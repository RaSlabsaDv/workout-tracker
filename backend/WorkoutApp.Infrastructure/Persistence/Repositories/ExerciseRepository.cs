using Microsoft.EntityFrameworkCore;

public class ExerciseRepository(WorkoutContext context) : IExerciseRepository
{
    public async Task AddAsync(Exercise exercise, CancellationToken ct = default)
    {
        await context.Exercises.AddAsync(exercise, ct);
    }

    public async Task<List<Exercise>> GetAllAsync(CancellationToken ct = default) =>
        await context.Exercises.Where(e => !e.IsArchived).ToListAsync(ct);

    public async Task<Exercise?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.Exercises.FindAsync([id], ct);

    public async Task<List<Exercise>> GetCustomByUserIdAsync(int userId, CancellationToken ct = default) =>
        await context.Exercises.Where(e => e.UserId == userId && e.IsCustom).ToListAsync(ct);

    public void Remove(Exercise exercise) =>
        context.Exercises.Remove(exercise);
}