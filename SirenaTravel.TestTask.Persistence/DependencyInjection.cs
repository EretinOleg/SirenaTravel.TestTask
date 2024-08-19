using Microsoft.Extensions.DependencyInjection;
using SirenaTravel.TestTask.Application.Core.Abstractions;

namespace SirenaTravel.TestTask.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IAirportRepository, AirportRepository>();

        return services;
    }
}
