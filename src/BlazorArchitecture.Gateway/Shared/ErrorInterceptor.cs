using System.Reflection;
using MediatR;

namespace BlazorArchitecture.Gateway.Shared;

public class ErrorInterceptor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse: Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            return CreateFailureResult<TResponse>();
        }
    }

    private static TResult CreateFailureResult<TResult>()
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (Result.Failure(new Error("Nope", ErrorType.Business)) as TResult)!; 
        }

        var resultObj = typeof(Result)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(m => m is { Name: nameof(Result.Failure), IsGenericMethod: true })
            .MakeGenericMethod(typeof(TResult).GenericTypeArguments[0])
            .Invoke(null, new object?[] { new Error("Nope", ErrorType.Business) });
        
        return (TResult)resultObj!;
    }
}