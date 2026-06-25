using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public record DeleteSubCommentCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
