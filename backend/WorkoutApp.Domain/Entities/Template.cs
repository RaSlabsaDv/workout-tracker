public class Template
{
    public int Id {get; private set;}
    public int UserId {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public User User { get; private set; } = null!;
    public ICollection<TemplateExercise> Exercises { get; private set; } = [];


    private Template(){}

    public Template(int userId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Template name cannot be empty.");
            
        UserId = userId;
        Name = name;
    }
}