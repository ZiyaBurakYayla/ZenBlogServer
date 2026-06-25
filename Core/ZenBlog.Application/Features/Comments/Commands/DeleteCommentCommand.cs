using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public record DeleteCommentCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
