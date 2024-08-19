using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using SirenaTravel.TestTask.Application.Core.Abstractions;
using SirenaTravel.TestTask.Domain.Airports;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;
using SirenaTravel.TestTask.Persistence.Raw;

namespace SirenaTravel.TestTask.Persistence;

internal class AirportRepository : IAirportRepository
{
    private const string BaseUrl = "https://places-dev.cteleport.com";
    private const string LoadPath = "airports/{code}";

    private readonly IMemoryCache _cache;

    public AirportRepository(IMemoryCache cache)
    {
        _cache = cache;
    }


    public async Task<Airport?> Load(AirportCode code, CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue(code.Value, out Airport? data))
            return data;

        using (var client = new RestClient(new RestClientOptions(BaseUrl)))
        {
            var source = await client.GetAsync<AirportSourceData>(LoadPath, 
                new 
                { 
                    code = code.Value 
                }, 
                cancellationToken);

            if (source?.Location is null)
                return null;

            var result = Airport.Create(source.Code, source.Location.Latitude, source.Location.Longitude);

            _cache.Set(code.Value, result);

            return result;
        }
    }
}
