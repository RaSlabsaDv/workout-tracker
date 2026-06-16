using Microsoft.EntityFrameworkCore;

public class WorkoutSetRepository(WorkoutContext context) : IWorkoutSetRepository
{
    public async Task AddAsync(WorkoutSet set, CancellationToken ct = default)
    {
        await context.WorkoutSets.AddAsync(set, ct);
    }

    public async Task<List<WorkoutSet>> GetByWorkoutExerciseIdAsync(int workoutExerciseId, CancellationToken ct = default) =>
        await context.WorkoutSets.Where(ws => ws.WorkoutExerciseId == workoutExerciseId).ToListAsync(ct);

    public async Task<WorkoutSet?> GetLastPerformanceAsync(int userId, int exerciseId, CancellationToken ct = default) =>
        await context.WorkoutSets.Where(ws => ws.WorkoutExercise.Session.UserId == userId 
            && ws.WorkoutExercise.ExerciseId == exerciseId
            && ws.CompletedAt != null)
        .OrderByDescending(ws => ws.CompletedAt)
        .FirstOrDefaultAsync(ct);

    public void Remove(WorkoutSet set) =>
        context.WorkoutSets.Remove(set);
}