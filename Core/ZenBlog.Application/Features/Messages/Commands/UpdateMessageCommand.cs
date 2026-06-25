using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record UpdateMessageCommand(Guid Id, string Name, string Email, string Subject, string MessageBody, bool IsRead) : IRequest<BaseResult<object>>;
}
