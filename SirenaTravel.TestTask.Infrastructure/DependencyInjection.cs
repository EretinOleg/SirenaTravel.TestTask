using Microsoft.Extensions.DependencyInjection;
using SirenaTravel.TestTask.Application.Core.Abstractions;

namespace SirenaTravel.TestTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDistanceCalculator, DistanceCalculator>();

        return services;
    }
}
