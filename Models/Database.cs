using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCorePlayground.Models;

public class Database: DbContext
{
    public DbSet<Advocate> Advocates => Set<Advocate>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=app.db")
            .EnableSensitiveDataLogging()
            .LogTo(
                Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advocate>()
            .HasData([
                new() { Id = 1, Name = "Maarten Balliauw", Products = [ "IntelliJ IDEA", "Rider", "ReSharper" ], Technologies = [".NET", "Java"]},
                new() { Id = 2, Name = "Matthias Koch", Products = ["ReSharper", "Rider", "Qodana", "Team City"], Technologies = [".NET", "CI" ]},
                new() { Id = 3, Name = "Rachel Appel", Products = ["ReSharper", "Rider"], Technologies = [".NET", "JavaScript"]},
                new() { Id = 4, Name = "Matt Ellis", Products = ["Rider", "Gateway"], Technologies = [".NET", "Unreal", "Unity", "Java"]},
                new() { Id = 5, Name = "Khalid Abuhakmeh", Products = ["Rider", "RustRover"], Technologies = [".NET", "Rust"]}
            ]);
    }
}

[Table("Advocates")]
public class Advocate
{
    [Key]
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; } = "";
    public string[] Products { get; set; } = [];
    public string[] Technologies { get; set; } = [];
}