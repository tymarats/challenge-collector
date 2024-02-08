using ChallengeCollector.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChallengeCollector;

public class ChallengeCollectorDbContext : DbContext
{
    public DbSet<ChallengeResponse> ChallengeResponses { get; set; }

    public ChallengeCollectorDbContext(DbContextOptions<ChallengeCollectorDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
