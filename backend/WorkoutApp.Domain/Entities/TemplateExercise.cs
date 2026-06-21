public class TemplateExercise
{
    public int Id {get; private set;}
    public int TemplateId {get; private set;}
    public int ExerciseId {get; private set;}
    public int DefaultSets {get; private set;}
    public int DefaultReps {get; private set;}
    public double? DefaultWeight {get; private set;}
    public int RestSeconds {get; private set;}
    public int Order {get; private set;}
    public Template Template { get; private set; } = null!;
    public Exercise Exercise { get; private set; } = null!;


    private TemplateExercise(){}

    public TemplateExercise(int templateId, int exerciseId, int defaultSets, int defaultReps, double? defaultWeight, int restSeconds, int order)
    {
        TemplateId = templateId;
        ExerciseId = exerciseId;
        DefaultSets = defaultSets;
        DefaultReps = defaultReps;
        DefaultWeight = defaultWeight;
        RestSeconds = restSeconds;
        Order = order;
    }

    public void UpdateOrder(int order)
    {
        if (order <= 0)
            throw new ArgumentException("Order must be greater than zero");

        Order = order;
    }
}