using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetCommentQueryHandler(IRepository<Comment> _repository, IMapper _mapper) :
        IRequestHandler<GetCommentQuery, BaseResult<List<GetCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentQueryResult>>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetCommentQueryResult>>(values);
            return BaseResult<List<GetCommentQueryResult>>.Success(response);
        }
    }
}
