namespace SirenaTravel.TestTask.Domain.Core;

public class StException: Exception
{
    public StException(string error): base(error)
    {
    }
}
