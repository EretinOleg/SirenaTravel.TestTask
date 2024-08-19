using SirenaTravel.TestTask.Application.Core.Abstractions;
using SirenaTravel.TestTask.Application.Core.Messaging;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Domain.Core;

namespace SirenaTravel.TestTask.Application.Airports.Queries.CalculateDistance;

public class CalculateDistanceQueryHandler : IQueryHandler<CalculateDistanceQuery, double>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IDistanceCalculator _distanceCalculator;

    public CalculateDistanceQueryHandler(
        IAirportRepository airportRepository, 
        IDistanceCalculator distanceCalculator)
    {
        _airportRepository = airportRepository;
        _distanceCalculator = distanceCalculator;
    }

    public async Task<double> Handle(CalculateDistanceQuery request, CancellationToken cancellationToken)
    {
        var fromCode = AirportCode.Create(request.FromCode);
        var toCode = AirportCode.Create(request.ToCode);

        if (fromCode == toCode)
            return 0.0d;

        var fromAirport = await _airportRepository.Load(fromCode, cancellationToken);
        if (fromAirport is null)
            throw new StException(Errors.UnableToLoadAirportData);

        var toAirport = await _airportRepository.Load(toCode, cancellationToken);
        if (toAirport is null)
            throw new StException(Errors.UnableToLoadAirportData);

        return _distanceCalculator.Calculate(fromAirport.Location, toAirport.Location);
    }
}
