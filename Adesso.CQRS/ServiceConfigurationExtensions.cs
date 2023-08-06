using Microsoft.Extensions.DependencyInjection;

namespace Adesso.CQRS;

public static class ServiceConfigurationExtensions
{
    public static void AddCqrsHandlers(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(ServiceConfigurationExtensions));
        });
    }
}