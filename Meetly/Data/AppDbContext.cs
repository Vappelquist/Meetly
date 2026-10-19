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
    }
}