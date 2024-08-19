using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SirenaTravel.TestTask.Api.Contracts;

public class ApiErrorResponse
{
    public ApiErrorResponse(IReadOnlyCollection<string> errors) => Errors = errors;


    public IReadOnlyCollection<string> Errors { get; }
}
