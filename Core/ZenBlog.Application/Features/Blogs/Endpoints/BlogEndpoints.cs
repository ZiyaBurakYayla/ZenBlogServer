using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;

namespace ZenBlog.Application.Features.Blogs.Endpoints
{
    public static class BlogEndpoints
    {
        public static async Task RegisterBlogEndpoints(this IEndpointRouteBuilder app)
        {
            var blogs = app.MapGroup("/blogs").WithTags("Blogs");

            blogs.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapGet("latest5blogs", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetLatest5BlogsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapPost(string.Empty, async (CreateBlogCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            blogs.MapPut(string.Empty, async (UpdateBlogCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            blogs.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
             {
                 var response = await _mediator.Send(new DeleteBlogCommand(Id));
                 return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
             });

            blogs.MapGet("byCategoryId/{categoryId}", async (Guid categoryId, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogsByCategoryIdQuery(categoryId));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();
        }
    }
}
