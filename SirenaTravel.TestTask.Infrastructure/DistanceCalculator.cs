using SirenaTravel.TestTask.Application.Core.Abstractions;
using SirenaTravel.TestTask.Domain.Airports.ValueObjects;

namespace SirenaTravel.TestTask.Infrastructure
{
    internal class DistanceCalculator : IDistanceCalculator
    {
        /// <summary>
        /// Radius of the earth in km
        /// </summary>
        public static int EarthRadius = 6371;

        /// <summary>
        /// Calculate distance between 2 geo points
        /// https://stackoverflow.com/questions/27928/calculate-distance-between-two-latitude-longitude-points-haversine-formula
        /// </summary>
        public double Calculate(Coordinate from, Coordinate to)
        {
            var dLat = Deg2Rad(to.Latitude - from.Latitude);
            var dLon = Deg2Rad(to.Longitude - from.Longitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(Deg2Rad(from.Latitude)) * Math.Cos(Deg2Rad(to.Latitude)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return Km2Miles(EarthRadius * c);
        }

        /// <summary>
        /// Convert distance in kilometers to miles
        /// </summary>
        public static double Km2Miles(double km)
            => km * 0.621371;

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        public static double Deg2Rad(double deg)
            => deg * (Math.PI / 180);
    }
}
