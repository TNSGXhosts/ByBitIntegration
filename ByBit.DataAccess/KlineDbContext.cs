using Microsoft.EntityFrameworkCore;
using ByBit.DataAccess.Entities;

namespace ByBit.DataAccess;

public class KlineDbContext : DbContext
{
    public KlineDbContext(DbContextOptions<KlineDbContext> options) : base(options)
    {
    }

    public DbSet<KlineEntity> Klines => Set<KlineEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KlineEntity>()
            .HasIndex(k => new { k.Symbol, k.Interval, k.StartTime })
            .IsUnique();
    }
}
