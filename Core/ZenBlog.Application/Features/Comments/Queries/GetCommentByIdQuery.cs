using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Queries
{
    public class GetCommentByIdQuery : IRequest<BaseResult<GetCommentByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
