using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.HasIndex(we => new { we.SessionId, we.Order })
            .IsUnique();

        builder.Property(p => p.Order)
            .IsRequired();

        builder.HasMany(x => x.Sets)
            .WithOne(s => s.WorkoutExercise)
            .HasForeignKey(s => s.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}