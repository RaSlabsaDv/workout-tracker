public class UnitOfWork(WorkoutContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default) =>
        await context.SaveChangesAsync(ct);
}