using Console;

System.Console.WriteLine(
    $"""
Moscow (SVO) - Kazan (KZN):
{GeoUtils.CalculateDistance(
        new GeoPoint(55.972820, 37.415357),
        new GeoPoint(55.605933, 49.283344)):F4} km
""");

System.Console.ReadKey();


