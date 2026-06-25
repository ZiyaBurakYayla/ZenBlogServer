using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Users.Commands
{
    public record DeleteUserCommand(string Id) : IRequest<BaseResult<bool>>;
}
