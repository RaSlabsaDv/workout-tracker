using Microsoft.EntityFrameworkCore;

public class UserRepository(WorkoutContext context) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        await context.Users.AddAsync(user, ct);
    }

    public async Task<bool> ExistsAsync(string email, CancellationToken ct = default) =>
        await context.Users.AnyAsync(u => u.Email == email, ct);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        await context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);

    public async Task<User?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.Users.FindAsync([id], ct);

    public void Remove(User user) =>
        context.Users.Remove(user);
}