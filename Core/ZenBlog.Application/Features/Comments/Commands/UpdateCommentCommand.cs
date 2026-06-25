using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public record UpdateCommentCommand(Guid Id, string FirstName, string LastName, string Email, string Body, DateTime Date, Guid BlogId) : IRequest<BaseResult<object>>;
}
