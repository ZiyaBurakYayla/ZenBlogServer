using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record DeleteContactInfoCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
