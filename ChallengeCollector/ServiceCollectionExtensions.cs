using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ChallengeCollector;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterPersistence(services, configuration);

        return services;
    }

    private static void RegisterPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ?? throw new Exception("Connection string not found.");
        services.AddDbContext<ChallengeCollectorDbContext>(
            (sp, options) =>
            {
                options
                    .UseNpgsql(connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                    .UseSnakeCaseNamingConvention();
            }
        );
    }
}
