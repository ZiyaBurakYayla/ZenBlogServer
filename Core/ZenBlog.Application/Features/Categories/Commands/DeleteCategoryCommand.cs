using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<BaseResult<bool>>;
}
