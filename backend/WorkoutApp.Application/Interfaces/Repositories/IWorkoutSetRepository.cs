public interface IWorkoutSetRepository
{
    Task AddAsync(WorkoutSet set, CancellationToken ct = default);
    Task<List<WorkoutSet>> GetByWorkoutExerciseIdAsync(int workoutExerciseId, CancellationToken ct = default);
    Task<WorkoutSet?> GetLastPerformanceAsync(int userId, int exerciseId, CancellationToken ct = default);
    void Remove(WorkoutSet set);
}