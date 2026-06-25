using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public class GetSocialByIdQuery : IRequest<BaseResult<GetSocialByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
