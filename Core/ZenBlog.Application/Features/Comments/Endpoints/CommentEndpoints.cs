using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Queries;

namespace ZenBlog.Application.Features.Comments.Endpoints
{
    public static class CommentEndpoints
    {
        public static async Task RegisterCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comments").WithTags("Comments");

            comments.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCommentQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapPost(string.Empty, async (CreateCommentCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            comments.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCommentByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapPut(string.Empty, async (UpdateCommentCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            comments.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteCommentCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
