public interface ITemplateExerciseRepository
{
    Task AddAsync(TemplateExercise templateExercise, CancellationToken ct = default);
    Task<TemplateExercise?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<TemplateExercise>> GetByTemplateIdAsync(int templateId, CancellationToken ct = default);
    void Remove(TemplateExercise templateExercise);
}