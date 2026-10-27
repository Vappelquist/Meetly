using Meetly.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meetly.Data;

public class AppDbContext : IdentityDbContext<user, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Meet> Meet { get; set; }
    public DbSet<user> User => Users;

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
            new user
            {
                Id = 4,
                UserName = "frank",
                NormalizedUserName = "FRANK",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000004",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000004"
            },
            new user
            {
                Id = 5,
                UserName = "grace",
                NormalizedUserName = "GRACE",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000005",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000005"
            },
            new user
            {
                Id = 6,
                UserName = "heidi",
                NormalizedUserName = "HEIDI",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000006",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000006"
            },
            new user
            {
                Id = 7,
                UserName = "ivan",
                NormalizedUserName = "IVAN",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000007",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000007"
            },
            new user
            {
                Id = 8,
                UserName = "judy",
                NormalizedUserName = "JUDY",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000008",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000008"
            },
            new user
            {
                Id = 9,
                UserName = "karl",
                NormalizedUserName = "KARL",
                PasswordHash = "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==",
                SecurityStamp = "00000000-0000-0000-0000-000000000009",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000009"
            }
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