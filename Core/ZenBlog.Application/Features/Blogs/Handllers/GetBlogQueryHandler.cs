using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handllers
{
    public class GetBlogQueryHandler(IRepository<Blog> _repository,IMapper _mapper) : 
        IRequestHandler<GetBlogQuery, BaseResult<List<GetBlogQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogQueryResult>>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetBlogQueryResult>>(values);
            return BaseResult<List<GetBlogQueryResult>>.Success(response);
        }
    }
}
