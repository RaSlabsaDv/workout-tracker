public class Exercise
{
    public int Id {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Category {get; private set;} = string.Empty;
    public bool IsCustom {get; private set;}
    public int? UserId {get; private set;}
    public ICollection<WorkoutExercise> WorkoutExercises { get; private set; } = [];
    public ICollection<PersonalRecord> PersonalRecords { get; private set; } = [];


    private Exercise(){}

    public Exercise(string name, string category, bool isCustom, int? userId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Exercise name cannot be empty.");
            
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be empty.");

        Name = name;
        Category = category;
        IsCustom = isCustom;
        UserId = userId;
    }
}