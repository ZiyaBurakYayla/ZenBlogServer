using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public record UpdateSubCommentCommand(Guid Id, string FirstName, string LastName, string Email, string Body, DateTime Date, Guid CommentId) : IRequest<BaseResult<object>>;
}
