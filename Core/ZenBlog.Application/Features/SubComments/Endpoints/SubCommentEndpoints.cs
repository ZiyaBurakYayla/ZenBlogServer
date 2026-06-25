using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Queries;

namespace ZenBlog.Application.Features.SubComments.Endpoints
{
    public static class SubCommentEndpoints
    {
        public static async Task RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComments = app.MapGroup("/subcomments").WithTags("SubComments");

            subComments.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapPost(string.Empty, async (CreateSubCommentCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            subComments.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSubCommentByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapPut(string.Empty, async (UpdateSubCommentCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            subComments.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteSubCommentCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
