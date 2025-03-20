namespace BlazorArchitecture.Gateway.Shared;

public class Result<T> : Result
{
    public T? Payload { get; init; }
    
    public TResponse Match<TResponse>(Func<T, TResponse> onSuccess, Func<Error, TResponse> onFailure)
    {
        return Error == null
            ? onSuccess(Payload!)
            : onFailure(Error);
    }
}

public class Result
{
    public Error? Error { get; private init; }

    public static Result Success()
    {
        return new Result();
    }
    
    public static Result<T> Success<T>(T payload)
    {
        return new Result<T> { Payload = payload };
    }

    public static Result Failure(Error error)
    {
        return new Result { Error = error };
    }
    
    public static Result<T> Failure<T>(Error error)
    {
        return new Result<T> { Error = error };
    }

    // public void Match(Action onSuccess, Action<Error> onFailure)
    // {
    //     if (Error == null) onSuccess();
    //     else onFailure(Error);
    // }
    
    // public TResponse Match<TResponse>(Func<TResponse> onSuccess, Func<Error, TResponse> onFailure)
    // {
    //     if (Error == null) return onSuccess();
    //     else return onFailure(Error);
    // }
}