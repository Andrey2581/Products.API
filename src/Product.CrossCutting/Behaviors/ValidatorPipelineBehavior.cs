using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Product.CrossCutting.Behaviors;

public class ValidatorPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        var errorList = validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validatorResult => validatorResult.Errors)
            .Where(validatorFailure => validatorFailure is not null)
            .Distinct()
            .ToList();

        if (errorList.Count <= 0)
            return await next();

        var result = BuildResponse<TResponse>(errorList);
        return result;
    }

    private static TResult BuildResponse<TResult>(IEnumerable<ValidationFailure> errors) where TResult : TResponse, new()
    {
        var result = new TResult();
        var errorList = errors.Select(e => new Error(e.ErrorMessage));
        result.Reasons.AddRange(errorList);

        return result;
    }
}