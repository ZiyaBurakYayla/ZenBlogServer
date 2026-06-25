using FluentValidation;
using MediatR;

namespace ZenBlog.Application.Behaviors
{
    public class ValidationBehavior<IRequest, IResponse>(IEnumerable<IValidator<IRequest>> _validators) : 
        IPipelineBehavior<IRequest, IResponse> where IRequest : class
    {
        public async Task<IResponse> Handle(IRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<IRequest>(request);

                var validationResult = await Task.WhenAll(
                    _validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResult.Where(result => result is not null)
                    .SelectMany(x => x.Errors).ToList();

                if(failures.Any())
                {
                    var errorDetails = failures.GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key,
                        x => x.Select(x => x.ErrorMessage).ToArray()
                        ).ToList();

                    throw new ValidationException(failures);
                }
            }

            return await next(cancellationToken);
        }
    }
}
