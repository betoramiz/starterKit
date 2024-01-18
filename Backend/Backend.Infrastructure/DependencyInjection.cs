using System.Text;
using Backend.Application.Common;
using Backend.Application.Data;
using Backend.Infrastructure.Authentication;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddPersistence(connectionString);
        return services;
    }
    
    // public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    // {
    //     var jwtSettings = new JwtSettings();
    //     configuration.Bind(JwtSettings.Section, jwtSettings);
    //
    //     services.AddSingleton(Options.Create(jwtSettings));
    //     services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    //
    //     services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
    //         .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    //         {
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidateLifetime = true,
    //             ValidateIssuerSigningKey = true,
    //             ValidIssuer = jwtSettings.Issuer,
    //             ValidAudience = jwtSettings.Audience,
    //             IssuerSigningKey = new SymmetricSecurityKey(
    //                 Encoding.UTF8.GetBytes(jwtSettings.Secret)),
    //         });
    //
    //
    //     return services;
    // }


    private static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
    {
        
        services.AddDbContext<BackendContext>((serviceProvider, options) =>
        {
            options.AddInterceptors(serviceProvider.GetService<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("Backend.Infrastructure"));
        });
        
        services.AddScoped<IBackendDbContext>(provider => provider.GetRequiredService<BackendContext>());
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        return services;
    }
    
}