using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.SubComments.Result;

namespace ZenBlog.Application.Features.SubComments.Queries
{
    public class GetSubCommentQuery : IRequest<BaseResult<List<GetSubCommentQueryResult>>>
    {
    }
}
