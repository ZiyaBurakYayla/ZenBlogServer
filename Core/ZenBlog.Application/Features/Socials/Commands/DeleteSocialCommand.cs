using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands
{
    public record DeleteSocialCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
