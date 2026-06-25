using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record DeleteMessageCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
