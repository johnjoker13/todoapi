using System.Reflection;
using Application.Common;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg =>
                cfg
                    .RegisterServicesFromAssembly(
                        typeof(DependencyInjectionRegister).Assembly
                    )
            )
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}