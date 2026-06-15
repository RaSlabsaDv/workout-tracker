public interface IWorkoutSessionRepository
{
    Task AddAsync(WorkoutSession session, CancellationToken ct = default);
    Task<WorkoutSession?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<WorkoutSession>> GetByUserIdAsync(int userId, CancellationToken ct = default);
    Task<WorkoutSession?> GetActiveAsync(int userId, CancellationToken ct = default);
    void Remove(WorkoutSession session);
}