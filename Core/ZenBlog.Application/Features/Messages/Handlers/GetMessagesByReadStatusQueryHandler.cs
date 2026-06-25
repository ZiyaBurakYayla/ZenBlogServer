using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessagesByReadStatusQueryHandler(IRepository<Message> _repository, IMapper _mapper) :
        IRequestHandler<GetMessagesByReadStatusQuery, BaseResult<List<GetMessageQueryResult>>>
    {
        public async Task<BaseResult<List<GetMessageQueryResult>>> Handle(GetMessagesByReadStatusQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var filtered = values.Where(x => x.IsRead == request.IsRead).ToList();
            var response = _mapper.Map<List<GetMessageQueryResult>>(filtered);
            return BaseResult<List<GetMessageQueryResult>>.Success(response);
        }
    }
}
