using FluentValidation;
using ZenBlog.Application.Base;

namespace ZenBlog.Api.CustomMiddlewares
{
    public class CustomExceptionHandLingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    data = (object?)null,
                    errors = ex.Errors.GroupBy(x => x.PropertyName)
                    .Select(x => new Dictionary<string, string>
                    {
                        { x.Key, x.First().ErrorMessage }
                    }).ToList()
                };

                await context.Response.WriteAsJsonAsync(response);
            }

            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { errormessage = ex.Message });
            }

        }
    }
}
