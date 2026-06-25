using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ContactInfos.Result;

namespace ZenBlog.Application.Features.ContactInfos.Queries
{
    public class GetContactInfoQuery : IRequest<BaseResult<List<GetContactInfoQueryResult>>>
    {
    }
}
