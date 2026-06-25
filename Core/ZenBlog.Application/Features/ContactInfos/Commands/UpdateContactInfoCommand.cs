using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record UpdateContactInfoCommand(Guid Id, string Address, string Email, string Phone, string MapUrl) : IRequest<BaseResult<object>>;
}
