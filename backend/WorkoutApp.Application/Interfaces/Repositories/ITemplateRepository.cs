public interface ITemplateRepository
{
    Task AddAsync(Template template, CancellationToken ct = default);
    Task<Template?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<Template>> GetByUserIdAsync(int userId, CancellationToken ct = default);
    void Remove(Template template);
}