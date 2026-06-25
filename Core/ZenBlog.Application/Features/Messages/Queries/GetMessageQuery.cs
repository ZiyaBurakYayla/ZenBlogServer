using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Messages.Result;

namespace ZenBlog.Application.Features.Messages.Queries
{
    public class GetMessageQuery : IRequest<BaseResult<List<GetMessageQueryResult>>>
    {
    }
}
