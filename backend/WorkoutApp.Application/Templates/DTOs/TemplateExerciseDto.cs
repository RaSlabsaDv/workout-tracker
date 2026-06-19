public record TemplateExerciseDto(
    int ExerciseId,
    int DefaultSets,
    int DefaultReps,
    double? DefaultWeight,
    int RestSeconds
);