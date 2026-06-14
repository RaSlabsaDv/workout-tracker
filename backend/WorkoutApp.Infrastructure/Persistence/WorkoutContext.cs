using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class WorkoutContext(DbContextOptions<WorkoutContext> options) : DbContext(options)
{
    public DbSet<User> Users {get; set;}
    public DbSet<Exercise> Exercises {get; set;}
    public DbSet<Template> Templates {get; set;}
    public DbSet<PersonalRecord> PersonalRecords {get; set;}
    public DbSet<TemplateExercise> TemplateExercises {get; set;}
    public DbSet<WorkoutExercise> WorkoutExercises {get; set;}
    public DbSet<WorkoutSession> WorkoutSessions {get; set;}
    public DbSet<WorkoutSet> WorkoutSets {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}