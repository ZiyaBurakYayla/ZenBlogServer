using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public class GetSocialQuery : IRequest<BaseResult<List<GetSocialQueryResult>>>
    {
    }
}
