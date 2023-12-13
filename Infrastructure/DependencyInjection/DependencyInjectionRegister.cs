using Application.Common;
using Infrastructure.Auth;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgresql"))
        );

        services
            .AddScoped<IUserRepository, UserRepository>();

        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}