using Backend.Application.Data;
using Backend.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddPersistence(connectionString);
        return services;
    }


    private static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
    {
        
        services.AddDbContext<BackendContext>(options =>
        {
            options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("Backend.Infrastructure"));
        });
        
        services.AddScoped<IBackendDbContext>(provider => provider.GetRequiredService<BackendContext>());

        return services;
    }
}