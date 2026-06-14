using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WorkoutSetConfiguration : IEntityTypeConfiguration<WorkoutSet>
{
    public void Configure(EntityTypeBuilder<WorkoutSet> builder)
    {
        builder.HasIndex(ws => new { ws.WorkoutExerciseId, ws.SetNumber })
            .IsUnique();

        builder.Property(p => p.SetNumber)
            .IsRequired();

        builder.Property(p => p.Reps)
            .IsRequired(false);
        
        builder.Property(p => p.Weight)
            .IsRequired(false);

        builder.Property(p => p.CompletedAt)
            .IsRequired(false);
    }
}