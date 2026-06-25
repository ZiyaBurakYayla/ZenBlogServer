using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.Endpoints
{
    public static class SocialEndpoints
    {
        public static async Task RegisterSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/socials").WithTags("Socials");

            socials.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            socials.MapPost(string.Empty, async (CreateSocialCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapPut(string.Empty, async (UpdateSocialCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            socials.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteSocialCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
