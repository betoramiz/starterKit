using Backend.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<BackendContext>(options =>
        {
            options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("ClientOpinion.Infrastructure"));
        });

        return services;
    }
}