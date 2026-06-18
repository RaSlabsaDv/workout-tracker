public class Exercise
{
    public int Id {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public ExerciseCategory Category {get; private set;}
    public bool IsCustom {get; private set;}
    public int? UserId {get; private set;}
    public User? User {get; private set;}
    public bool IsArchived { get; private set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; private set; } = [];
    public ICollection<PersonalRecord> PersonalRecords { get; private set; } = [];


    private Exercise(){}

    public Exercise(string name, ExerciseCategory category, bool isCustom, int? userId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Exercise name cannot be empty.");

        Name = name;
        Category = category;
        IsCustom = isCustom;
        UserId = userId;
    }

    public void Archive() => IsArchived = true;

    public void Update(string name, ExerciseCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Exercise name cannot be empty.");

        Name = name;
        Category = category;
    }
}