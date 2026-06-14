using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasMany(t => t.Exercises)
            .WithOne(te => te.Template)
            .HasForeignKey(te => te.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}