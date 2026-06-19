using Microsoft.EntityFrameworkCore;

public class TemplateRepository(WorkoutContext context) : ITemplateRepository
{
    public async Task AddAsync(Template template, CancellationToken ct = default)
    {
        await context.Templates.AddAsync(template, ct);
    }

    public async Task<Template?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await context.Templates
            .Include(t => t.Exercises)
            .FirstOrDefaultAsync(t => t.Id == id, ct);

    public async Task<List<Template>> GetByUserIdAsync(int userId, CancellationToken ct = default) =>
        await context.Templates.Where(t => t.UserId == userId).ToListAsync(ct);

    public void Remove(Template template) =>
        context.Templates.Remove(template);
}