using Microsoft.EntityFrameworkCore;

public class WorkoutSessionRepository(WorkoutContext context) : IWorkoutSessionRepository
{
    public async Task AddAsync(WorkoutSession session, CancellationToken ct = default)
    {
        await context.WorkoutSessions.AddAsync(session, ct);
    }

    public async Task<WorkoutSession?> GetActiveAsync(int userId, CancellationToken ct = default) =>
        await context.WorkoutSessions.FirstOrDefaultAsync(ws => ws.UserId == userId && ws.IsActive, ct);

    public async Task<WorkoutSession?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.WorkoutSessions.FindAsync([id], ct);

    public async Task<List<WorkoutSession>> GetByUserIdAsync(int userId, CancellationToken ct = default) =>
        await context.WorkoutSessions.Where(ws => ws.UserId == userId).ToListAsync(ct);

    public void Remove(WorkoutSession session) =>
        context.WorkoutSessions.Remove(session);
}