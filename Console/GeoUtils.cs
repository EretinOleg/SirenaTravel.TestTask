namespace Console;

internal static class GeoUtils
{
    /// <summary>
    /// Radius of the earth in km
    /// </summary>
    public static int EarthRadius = 6371;

    /// <summary>
    /// Calculate distance between 2 geo points
    /// https://stackoverflow.com/questions/27928/calculate-distance-between-two-latitude-longitude-points-haversine-formula
    /// </summary>
    public static double CalculateDistance(GeoPoint point1, GeoPoint point2)
    {
        var dLat = Deg2Rad(point2.Latitude - point1.Latitude);
        var dLon = Deg2Rad(point2.Longitude - point1.Longitude);
        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Deg2Rad(point1.Latitude)) * Math.Cos(Deg2Rad(point2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthRadius * c;
    }

    /// <summary>
    /// Convert degrees to radians
    /// </summary>
    public static double Deg2Rad(double deg)
        => deg * (Math.PI / 180);
}
