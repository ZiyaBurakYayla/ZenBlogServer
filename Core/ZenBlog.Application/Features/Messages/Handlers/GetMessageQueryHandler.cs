using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessageQueryHandler(IRepository<Message> _repository, IMapper _mapper) :
        IRequestHandler<GetMessageQuery, BaseResult<List<GetMessageQueryResult>>>
    {
        public async Task<BaseResult<List<GetMessageQueryResult>>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetMessageQueryResult>>(values);
            return BaseResult<List<GetMessageQueryResult>>.Success(response);
        }
    }
}
