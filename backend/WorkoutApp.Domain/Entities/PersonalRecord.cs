public class PersonalRecord
{
    public int Id {get; private set;}
    public int UserId {get; private set;}
    public int ExerciseId {get; private set;}
    public double Weight {get; private set;}
    public int Reps {get; private set;}
    public double EstimatedOneRm {get; private set;}
    public DateTime AchievedAt {get; private set;}
    public Exercise Exercise { get; private set; } = null!;
    public User User { get; private set; } = null!;


    private PersonalRecord(){}

    public PersonalRecord(int userId, int exerciseId, double weight, int reps, double estimatedOneRm)
    {
        UserId = userId;
        ExerciseId = exerciseId;
        Weight = weight;
        Reps = reps;
        EstimatedOneRm = estimatedOneRm;
        AchievedAt = DateTime.UtcNow;
    }
}