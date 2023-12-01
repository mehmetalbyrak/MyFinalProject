namespace Core.Utilities.Results;

public class Result :IResult
{
    public Result(bool success, string message):this(success)
    {
        Message = message; //setter in constructor only at here !!!
        
    }
    
    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }

    public string Message { get; }
}