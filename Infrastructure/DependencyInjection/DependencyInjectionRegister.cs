using System.Text;
using Application.Common;
using Infrastructure.Auth;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.AddPersistence(configuration);
        services.AddAuth(configuration);

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.AddDbContext<TodoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!)
        );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = jwtSettings.Issuer,
                 ValidAudience = jwtSettings.Audience,
                 IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(jwtSettings.Secret))
             });



        return services;
    }
}