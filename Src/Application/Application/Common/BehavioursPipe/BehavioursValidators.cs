#region UsingAndNamespace
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Application.Common.BehavioursPipe;
#endregion
public class BehavioursValidators<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    #region CtorAndInjection
    private readonly ILogger<TRequest> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public BehavioursValidators(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
    {
        _validators = validators;
        _logger = logger;
    }
    #endregion


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next().ConfigureAwait(false);
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v =>
            v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any())
            throw new ValidationEntityException(failures);

        return await next().ConfigureAwait(false);
    }
}
