using Microsoft.EntityFrameworkCore;
using TestTask.Infrastructure.Models;

namespace TestTask.Infrastructure;

public partial class TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logs_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}