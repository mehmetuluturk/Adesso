using System.Reflection;
using Adesso.Domain;
using Adesso.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Infrastructure;

public static class ServiceConfigurationExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITravelRepository, TravelRepository>();
    }
}