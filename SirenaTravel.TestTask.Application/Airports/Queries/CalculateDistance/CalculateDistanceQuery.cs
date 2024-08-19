using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Application.Core.Messaging;

namespace SirenaTravel.TestTask.Application.Airports.Queries.CalculateDistance;

public record CalculateDistanceQuery(string FromCode, string ToCode): IQuery<double>;
