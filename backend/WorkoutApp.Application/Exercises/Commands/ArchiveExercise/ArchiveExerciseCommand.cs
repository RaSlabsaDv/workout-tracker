using MediatR;

public record ArchiveExerciseCommand(int ExerciseId, int UserId) : IRequest;