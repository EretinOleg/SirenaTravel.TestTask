namespace SirenaTravel.TestTask.Domain.Airports.Errors;

public static class Airport
{
    public static class Code
    {
        public const string IncorrectLength = "Неверная длина кода аэропорта";

        public const string InvalidFormat = "Неверный формат кода аэропорта";
    }

    public static class Latitude
    {
        public const string OutOfRangeValue = "Неверное значение для широты";
    }

    public static class Longitude
    {
        public const string OutOfRangeValue = "Неверное значение для долготы";
    }
}
