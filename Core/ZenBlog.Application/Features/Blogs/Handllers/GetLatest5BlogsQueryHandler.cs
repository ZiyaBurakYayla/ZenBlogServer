using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handllers
{
    public class GetLatest5BlogsQueryHandler(IRepository<Blog> _repository, IMapper _mapper) :
        IRequestHandler<GetLatest5BlogsQuery, BaseResult<List<GetBlogQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogQueryResult>>> Handle(GetLatest5BlogsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var latest = values.OrderByDescending(x => x.CreatedAt).Take(5).ToList();
            var response = _mapper.Map<List<GetBlogQueryResult>>(latest);
            return BaseResult<List<GetBlogQueryResult>>.Success(response);
        }
    }
}
