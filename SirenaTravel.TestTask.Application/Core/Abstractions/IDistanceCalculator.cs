using SirenaTravel.TestTask.Domain.Airports.ValueObjects;

namespace SirenaTravel.TestTask.Application.Core.Abstractions;

public interface IDistanceCalculator
{
    double Calculate(Coordinate from, Coordinate to);
}
