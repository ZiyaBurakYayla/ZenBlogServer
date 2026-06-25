using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.SubComments.Result;

namespace ZenBlog.Application.Features.SubComments.Queries
{
    public class GetSubCommentByIdQuery : IRequest<BaseResult<GetSubCommentByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
