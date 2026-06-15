public interface IExerciseRepository
{
    Task AddAsync(Exercise exercise, CancellationToken ct = default);
    Task<Exercise?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<Exercise>> GetAllAsync(CancellationToken ct = default);
    Task<List<Exercise>> GetCustomByUserIdAsync(int userId, CancellationToken ct = default);
    void Remove(Exercise exercise);
}