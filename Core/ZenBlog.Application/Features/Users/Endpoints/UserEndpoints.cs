using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Application.Features.Users.Queries;

namespace ZenBlog.Application.Features.Users.Endpoints
{
    public static class UserEndpoints
    {
        public static async Task RegisterUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users");

            users.MapPost("register", async (CreateUserCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            users.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetUserQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapGet("{id}", async (string id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetUserByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapPut(string.Empty, async (UpdateUserCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapDelete("{id}", async (string id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteUserCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapPost("Login", async (IMediator _mediator, GetLoginQuery _query) =>
            {
                var response = await _mediator.Send(_query);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();
        }
    }
}
