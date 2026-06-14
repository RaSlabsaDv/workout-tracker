public class User
{
    public int Id {get; private set;}
    public string Email {get; private set;} = string.Empty;
    public string PasswordHash {get; private set;} = string.Empty;
    public ICollection<Exercise> Exercises {get; private set;} = [];
    public ICollection<Template> Templates { get; private set; } = [];
    public ICollection<WorkoutSession> Sessions { get; private set; } = [];
    public ICollection<PersonalRecord> PersonalRecords { get; private set; } = [];


    private User(){}

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
}