using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(i => i.Email)
            .IsUnique();

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.PasswordHash)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(x => x.Exercises)
            .WithOne(e => e.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Templates)
            .WithOne(t => t.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Sessions)
            .WithOne(s => s.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PersonalRecords)
            .WithOne(pr => pr.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}