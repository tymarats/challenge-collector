using Microsoft.EntityFrameworkCore;

namespace ChallengeCollector;

public static class MigrationUtil
{
    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ChallengeCollectorDbContext>();
        context.Database.Migrate();
    }
}
