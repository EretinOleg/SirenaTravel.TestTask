using SirenaTravel.TestTask.Domain.Airports;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;

namespace SirenaTravel.TestTask.Application.Core.Abstractions;

public interface IAirportRepository
{
    Task<Airport?> Load(AirportCode code, CancellationToken cancellationToken);
}
