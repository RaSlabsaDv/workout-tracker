public class WorkoutExercise
{
    public int Id {get; private set;}
    public int SessionId {get; private set;}
    public int ExerciseId {get; private set;}
    public int Order {get; private set;}
    public WorkoutSession Session { get; private set; } = null!;
    public Exercise Exercise { get; private set; } = null!;
    public ICollection<WorkoutSet> Sets { get; private set; } = [];


    private WorkoutExercise(){}

    public WorkoutExercise(int sessionId, int exerciseId, int order)
    {
        SessionId = sessionId;
        ExerciseId = exerciseId;
        Order = order;
    }
}