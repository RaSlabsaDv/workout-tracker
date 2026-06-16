using Microsoft.EntityFrameworkCore;

public class WorkoutExerciseRepository(WorkoutContext context) : IWorkoutExerciseRepository
{
    public async Task AddAsync(WorkoutExercise workoutExercise, CancellationToken ct = default)
    {
        await context.WorkoutExercises.AddAsync(workoutExercise, ct);
    }

    public async Task<WorkoutExercise?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.WorkoutExercises.FindAsync([id], ct);
    public async Task<List<WorkoutExercise>> GetBySessionIdAsync(int sessionId, CancellationToken ct = default) =>
        await context.WorkoutExercises.Where(we => we.SessionId == sessionId).ToListAsync(ct);

    public void Remove(WorkoutExercise workoutExercise) =>
        context.WorkoutExercises.Remove(workoutExercise);
}