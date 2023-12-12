using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<UserDbContext>(
            options => options
                .UseNpgsql("Host=localhost:5432; Database=tododb; Username=postgres; Password=postgres;")
        );

        services
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}