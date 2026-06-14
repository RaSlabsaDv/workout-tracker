public class WorkoutSet
{
    public int Id {get; private set;}
    public int WorkoutExerciseId {get; private set;}
    public int SetNumber {get; private set;}
    public double? Weight {get; private set;}
    public int? Reps {get; private set;}
    public DateTime? CompletedAt {get; private set;}
    public WorkoutExercise WorkoutExercise { get; private set; } = null!;


    private WorkoutSet(){}

    public WorkoutSet(int workoutExerciseId, int setNumber)
    {
        WorkoutExerciseId = workoutExerciseId;
        SetNumber = setNumber;
    }

    public void Complete(double weight, int reps)
    {
        if (weight < 0)
            throw new ArgumentException("Weight cannot be negative.");
            
        if (reps <= 0)
            throw new ArgumentException("Reps must be greater than zero.");

        Weight = weight;
        Reps = reps;
        CompletedAt = DateTime.UtcNow;
    }
}