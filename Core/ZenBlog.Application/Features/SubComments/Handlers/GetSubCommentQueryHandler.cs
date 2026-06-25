using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentQueryHandler(IRepository<SubComment> _repository, IMapper _mapper) :
        IRequestHandler<GetSubCommentQuery, BaseResult<List<GetSubCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetSubCommentQueryResult>>> Handle(GetSubCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetSubCommentQueryResult>>(values);
            return BaseResult<List<GetSubCommentQueryResult>>.Success(response);
        }
    }
}
