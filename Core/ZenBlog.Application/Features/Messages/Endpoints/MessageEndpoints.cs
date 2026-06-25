using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.Application.Features.Messages.Endpoints
{
    public static class MessageEndpoints
    {
        public static async Task RegisterMessageEndpoints(this IEndpointRouteBuilder app)
        {
            var messages = app.MapGroup("/messages").WithTags("Messages");

            messages.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessageQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            messages.MapGet("unread", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessagesByReadStatusQuery(false));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            messages.MapGet("read", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessagesByReadStatusQuery(true));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            messages.MapPost(string.Empty, async (CreateMessageCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            messages.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessageByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            messages.MapPut(string.Empty, async (UpdateMessageCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            messages.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteMessageCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
