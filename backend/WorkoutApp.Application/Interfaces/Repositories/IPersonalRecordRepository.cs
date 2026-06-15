public interface IPersonalRecordRepository
{
    Task AddAsync(PersonalRecord record, CancellationToken ct = default);
    Task<PersonalRecord?> GetByUserAndExerciseAsync(int userId, int exerciseId, CancellationToken ct = default);
    Task<List<PersonalRecord>> GetByUserAsync(int userId, CancellationToken ct = default);
    void Remove(PersonalRecord record); 
}