using CSharpFunctionalExtensions;
using SirenaTravel.TestTask.Domain.Core;
using System.Text.RegularExpressions;

namespace SirenaTravel.TestTask.Domain.Airports.ValueObjects;

public class AirportCode: SimpleValueObject<string>
{
    public const int Length = 3;

    public const string RegexPattern = "^[A-Z]{3}$";

    private static readonly Lazy<Regex> FormatRegex = new Lazy<Regex>(() => new Regex(RegexPattern, RegexOptions.Compiled));

    private AirportCode(string value) : base(value)
    {
    }

    public static AirportCode Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new StException(Errors.Airport.Code.InvalidFormat);

        var value = code.Trim().ToUpper();

        if (value.Length != Length)
            throw new StException(Errors.Airport.Code.IncorrectLength);

        if (!FormatRegex.Value.IsMatch(value))
            throw new StException(Errors.Airport.Code.InvalidFormat);

        return new AirportCode(value);
    }
}
