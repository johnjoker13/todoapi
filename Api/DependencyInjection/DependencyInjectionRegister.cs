namespace Api.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentantion(this IServiceCollection services)
    {
        services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer()
            .AddControllers();

        return services;
    }
}