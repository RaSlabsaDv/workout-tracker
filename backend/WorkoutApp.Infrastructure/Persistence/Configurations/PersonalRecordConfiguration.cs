using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonalRecordConfiguration : IEntityTypeConfiguration<PersonalRecord>
{
    public void Configure(EntityTypeBuilder<PersonalRecord> builder)
    {
        builder.HasIndex(pr => new { pr.UserId, pr.ExerciseId })
            .IsUnique();

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Reps)
            .IsRequired();

        builder.Property(p => p.EstimatedOneRm)
            .IsRequired();

        builder.Property(p => p.AchievedAt)
            .IsRequired();
    }
}