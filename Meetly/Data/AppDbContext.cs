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
            .WithMany(u => u.AttendingMeets)
            .UsingEntity(j => j.HasData(

                new { AttendesId = 5, AttendingMeetsId = 1 },
                new { AttendesId = 6, AttendingMeetsId = 1 },
                new { AttendesId = 7, AttendingMeetsId = 2 },
                new { AttendesId = 8, AttendingMeetsId = 2 },
                new { AttendesId = 9, AttendingMeetsId = 3 },
                new { AttendesId = 4, AttendingMeetsId = 3 },

                new { AttendesId = 4, AttendingMeetsId = 5 },
                new { AttendesId = 4, AttendingMeetsId = 6 },
                new { AttendesId = 5, AttendingMeetsId = 4 },
                new { AttendesId = 7, AttendingMeetsId = 4 },
                new { AttendesId = 8, AttendingMeetsId = 5 },
                new { AttendesId = 9, AttendingMeetsId = 6 }
            ));
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        modelBuilder.Entity<user>().HasData(
            new user { Id = 4, Name = "frank", PasswordHash = "password123" },
            new user { Id = 5, Name = "grace", PasswordHash = "password123" },
            new user { Id = 6, Name = "heidi", PasswordHash = "password123" },
            new user { Id = 7, Name = "ivan", PasswordHash = "password123" },
            new user { Id = 8, Name = "judy", PasswordHash = "password123" },
            new user { Id = 9, Name = "karl", PasswordHash = "password123" }
        );

        modelBuilder.Entity<Meet>().HasData(
            new Meet
            {
                Id = 1,
                title = "Team Meeting",
                description = "Weekly team meeting",
                Place = "Conference Room",
                Time = new DateTime(2026, 11, 1, 10, 0, 0, DateTimeKind.Utc),
                HostId = 4,
                maxCapacity = 10
            },
            new Meet
            {
                Id = 2,
                title = "Project Kickoff",
                description = "Kickoff meeting for the new project",
                Place = "Zoom",
                Time = new DateTime(2026, 11, 2, 14, 0, 0, DateTimeKind.Utc),
                HostId = 5,
                maxCapacity = 20
            },
            new Meet
            {
                Id = 3,
                title = "Workshop",
                description = "Hands-on workshop on new technology",
                Place = "Lab 1",
                Time = new DateTime(2026, 11, 3, 9, 30, 0, DateTimeKind.Utc),
                HostId = 6,
                maxCapacity = 3
            },

            new Meet
            {
                Id = 4,
                title = "Summer Hackathon 2026",
                description = "48-hour prototype challenge and pizza.",
                Place = "Main Auditorium",
                Time = new DateTime(2026, 8, 15, 9, 0, 0, DateTimeKind.Utc),
                HostId = 4,
                maxCapacity = 40
            },
            new Meet
            {
                Id = 5,
                title = "React & Azure Workshop",
                description = "Deep dive into React frontend and ASP.NET Core Azure hosting.",
                Place = "Lab 2",
                Time = new DateTime(2026, 9, 20, 13, 0, 0, DateTimeKind.Utc),
                HostId = 5,
                maxCapacity = 15
            },
            new Meet
            {
                Id = 6,
                title = "Initial Design Sync",
                description = "Discussing the UI/UX layout and prototype screens.",
                Place = "Room 204",
                Time = new DateTime(2026, 10, 5, 15, 0, 0, DateTimeKind.Utc),
                HostId = 6,
                maxCapacity = 8
            }
        );
    }
}