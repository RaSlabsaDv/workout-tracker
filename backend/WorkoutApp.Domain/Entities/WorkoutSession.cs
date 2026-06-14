public class WorkoutSession
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int? TemplateId { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public bool IsActive => FinishedAt is null;
    public User User { get; private set; } = null!;
    public ICollection<WorkoutExercise> Exercises { get; private set; } = [];

    private WorkoutSession() { }

    public WorkoutSession(int userId, int? templateId)
    {
        UserId = userId;
        TemplateId = templateId;
        StartedAt = DateTime.UtcNow;
    }

    public void Finish()
    {
        if (FinishedAt.HasValue)
            throw new InvalidOperationException("Session already finished.");
            
        FinishedAt = DateTime.UtcNow;
    }
}