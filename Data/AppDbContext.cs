using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data;

public class AppDbContext : DbContext
{
    public DbSet<UrlMapping> UrlMappings { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UrlMapping>()
            .HasIndex(u => u.Key)
            .IsUnique();
    }
}
