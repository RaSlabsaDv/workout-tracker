using Microsoft.EntityFrameworkCore;

public class PersonalRecordRepository(WorkoutContext context) : IPersonalRecordRepository
{
    public async Task AddAsync(PersonalRecord record, CancellationToken ct = default)
    {
        await context.PersonalRecords.AddAsync(record, ct);
    }

    public async Task<PersonalRecord?> GetByUserAndExerciseAsync(int userId, int exerciseId, CancellationToken ct = default) =>
        await context.PersonalRecords.FirstOrDefaultAsync(pr => pr.UserId == userId && pr.ExerciseId == exerciseId, ct);

    public async Task<List<PersonalRecord>> GetByUserAsync(int userId, CancellationToken ct = default) =>
        await context.PersonalRecords.Where(pr => pr.UserId == userId)
            .ToListAsync(ct);

    public void Remove(PersonalRecord record) =>
        context.PersonalRecords.Remove(record);
}