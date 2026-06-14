using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TemplateExerciseConfiguration : IEntityTypeConfiguration<TemplateExercise>
{
    public void Configure(EntityTypeBuilder<TemplateExercise> builder)
    {
        builder.HasIndex(te => new { te.TemplateId, te.Order })
            .IsUnique();

        builder.Property(p => p.DefaultSets)
            .IsRequired();

        builder.Property(p => p.DefaultReps)
            .IsRequired();

        builder.Property(p => p.DefaultWeight)
            .IsRequired(false);

        builder.Property(p => p.RestSeconds)
            .IsRequired();

        builder.Property(p => p.Order)
            .IsRequired();
    }
}