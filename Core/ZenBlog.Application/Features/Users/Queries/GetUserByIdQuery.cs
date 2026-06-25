using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<BaseResult<GetUserByIdQueryResult>>
    {
        public string Id { get; set; }
    }
}
