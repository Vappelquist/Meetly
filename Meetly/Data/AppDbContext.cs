using Meetly.Models;
using Microsoft.EntityFrameworkCore;

namespace Meetly.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Meet> Meet { get; set; }
    public DbSet<user> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Meet>()
            .HasOne(m => m.Host)
            .WithMany(u => u.HostedMeets)
            .HasForeignKey(m => m.HostId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Meet>()
            .HasMany(m => m.Attendes)
            .WithMany(u => u.AttendingMeets);

        modelBuilder.Entity<user>().HasData(
            new user
            {
                Id = 1,
                Name = "stig",
                PasswordHash = "password123"
            },
            new user
            {
                Id = 2,
                Name = "bob",
                PasswordHash = "password123"
            },
            new user
            {
                Id = 3,
                Name = "alice",
                PasswordHash = "password123"
            },
            new user
            {
                Id = 4,
                Name = "charlie",
                PasswordHash = "password123"
            },
            new user
            {
                Id = 5,
                Name = "dave",
                PasswordHash = "password123"
            }
            new user
            {
                Id = 6,
                Name = "eve",
                PasswordHash = "password123"
            }
        );

        modelBuilder.Entity<Meet>().HasData(
            new Meet
            {
                Id = 1,
                title = "Team Meeting",
                description = "Weekly team meeting",
                Place = "Conference Room",
                Time = DateTime.Now,
                HostId = 1,
                maxCapacity = 10
            },
            new Meet
            {
                Id = 2,
                title = "Project Kickoff",
                description = "Kickoff meeting for the new project",
                Place = "Zoom",
                Time = DateTime.Now.AddDays(1),
                HostId = 2,
                maxCapacity = 20
            },
            new Meet
            {
                Id = 3,
                title = "Workshop",
                description = "Hands-on workshop on new technology",
                Place = "Lab 1",
                Time = DateTime.Now.AddDays(2),
                HostId = 3,
                maxCapacity = 3
            }
        );

        modelBuilder.Entity<Meet>()
    .HasMany(m => m.Attendes)
    .WithMany(u => u.AttendingMeets)
    .UsingEntity(j => j.HasData(
        new { AttendesId = 2, AttendingMeetsId = 1 },
        new { AttendesId = 3, AttendingMeetsId = 1 },
        new { AttendesId = 4, AttendingMeetsId = 2 },
        new { AttendesId = 5, AttendingMeetsId = 2 },
        new { AttendesId = 6, AttendingMeetsId = 3 },
        new { AttendesId = 1, AttendingMeetsId = 3 }

    ));
    }
}