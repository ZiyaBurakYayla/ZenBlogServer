using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handllers
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository, IMapper _mapper) :
        IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog Not Found");
            }

            var blog = _mapper.Map<GetBlogByIdQueryResult>(value);
            return BaseResult<GetBlogByIdQueryResult>.Success(blog);
        }
    }
}
