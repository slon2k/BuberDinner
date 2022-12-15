﻿using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            this.validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validator is null)
            {
                return await next();
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
            
            return (dynamic)errors;
        }
    }
}
