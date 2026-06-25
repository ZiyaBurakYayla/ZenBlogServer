using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints
{
    public static class ContactInfoEndpoints
    {
        public static async Task RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/contactinfos").WithTags("ContactInfos");

            contactInfos.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfoQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            contactInfos.MapPost(string.Empty, async (CreateContactInfoCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfos.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfoByIdQuery { Id = id });
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfos.MapPut(string.Empty, async (UpdateContactInfoCommand _command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(_command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            contactInfos.MapDelete("{Id}", async (Guid Id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new DeleteContactInfoCommand(Id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
