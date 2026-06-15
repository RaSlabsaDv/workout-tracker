public interface IWorkoutExerciseRepository
{
    Task AddAsync(WorkoutExercise workoutExercise, CancellationToken ct = default);
    Task<WorkoutExercise?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<WorkoutExercise>> GetBySessionIdAsync(int sessionId, CancellationToken ct = default);
    void Remove(WorkoutExercise workoutExercise);
}