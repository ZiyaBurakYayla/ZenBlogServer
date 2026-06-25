using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<BaseResult<object>>
    {
        public string CategoryName { get; set; }
    }
}
