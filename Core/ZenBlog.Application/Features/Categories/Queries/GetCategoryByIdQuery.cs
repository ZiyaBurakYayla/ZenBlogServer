using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;

namespace ZenBlog.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<BaseResult<GetCategoryByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
