using FluentResults;
using MediatR;

namespace Product.CrossCutting.GlobalException;

public class GlobalExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            var result = BuildResponse<TResponse>(exception);
            return result;
        }
    }

    private static TResult BuildResponse<TResult>(Exception exception) where TResult : TResponse, new()
    {
        var result = new TResult();
        result.Reasons.Add(new Error(exception.Message));

        return result;
    }
}