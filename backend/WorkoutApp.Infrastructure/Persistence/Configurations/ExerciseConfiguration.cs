using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.Category)
            .IsRequired()
            .HasConversion<string>();
           
        builder.Property(e => e.UserId)
            .IsRequired(false);

        builder.HasOne<User>()
            .WithMany(u => u.Exercises)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        builder.HasMany(x => x.WorkoutExercises)
            .WithOne(we => we.Exercise)
            .HasForeignKey(e => e.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.PersonalRecords)
            .WithOne(pr => pr.Exercise)
            .HasForeignKey(e => e.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(e => !e.IsArchived);
    }
}