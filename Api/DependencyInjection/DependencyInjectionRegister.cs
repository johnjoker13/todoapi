using Api.Common;

namespace Api.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentantion(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();

        return services;
    }
}